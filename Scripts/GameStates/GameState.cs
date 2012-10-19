using UnityEngine;
using System.Collections;

public class GameState : AbstractGameState {

	
	public GameState(GameManager manager) : base(manager) {}
	
	public override IEnumerator Enter ()
	{
		Application.LoadLevel("game");
		yield return null;
	}
	
	public override IEnumerator Exit ()
	{
		yield return null;
	}
	
	public override IEnumerator Pause (bool bPaused)
	{
		yield return null;
	}
	
	public override void Update ()
	{
		
	}
}
