using UnityEngine;
using System.Collections;

public class GameManager : UnitySingleton<GameManager> 
{
	
	public AbstractGameState GameState { get; set;}
	
	public override void Init ()
	{
		base.Init ();
		ChangeState(new MainMenuState(this));
	}
	
	public void ChangeState(AbstractGameState newState)
	{
		StartCoroutine(ChangeStateCoroutine(newState));
	}
	
	private IEnumerator ChangeStateCoroutine(AbstractGameState newState)
	{
		if( GameState != null )
			yield return GameState.Exit();
		
		GameState = newState;
		
		yield return newState.Enter();
	}
	
	
}
