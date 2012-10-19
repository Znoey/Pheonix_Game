using UnityEngine;
using System.Collections;

public class GameManager : UnitySingleton<GameManager> 
{
	
	public AbstractGameState GameState { get; set;}
	public bool bChangingState = false;
	
	public override void Init ()
	{
		base.Init ();
		Debug.Log("Init");
		DontDestroyOnLoad(gameObject);
		GameState = null;
	}
	
	public void Start()
	{
		Debug.Log("STart");
		ChangeState(new MainMenuState(this));
	}
	
	public void ChangeState(AbstractGameState newState)
	{
		StartCoroutine(ChangeStateCoroutine(newState));
	}
	
	private IEnumerator ChangeStateCoroutine(AbstractGameState newState)
	{
		bChangingState = true;
		Debug.Log("Changing State to " + newState.ToString());
		if( GameState != null )
			yield return StartCoroutine(GameState.Exit());
		
		GameState = newState;
		
		yield return StartCoroutine(GameState.Enter());
		bChangingState = false;		
	}
	
	public void Update()
	{
		if ( GameState != null && !bChangingState)
		{
			GameState.Update();
		}
	}
	
	
}
