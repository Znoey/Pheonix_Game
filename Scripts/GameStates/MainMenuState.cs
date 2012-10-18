using UnityEngine;
using System.Collections;

public class MainMenuState : AbstractGameState {
	
	
	public MainMenuState(GameManager manager) : base(manager)
	{
	
	}	
	
	public override IEnumerator Enter ()
	{
		yield return null;
	}
	
	public override IEnumerator Pause (bool bPaused)
	{
		// this state is impossible to pause.
		yield return null;
	}
	
	public override IEnumerator Update ()
	{
		yield return null;
	}
	
	public override IEnumerator Exit ()
	{
		yield return null;
	}
}
