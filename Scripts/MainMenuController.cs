using UnityEngine;
using System.Collections;

public class MainMenuController : UnitySingleton<MainMenuController> {
	
	public void PlayButton()
	{
		Debug.Log("Play Pressed.");
	}
	
	public void ExitButton()
	{
		Debug.Log("Exit Pressed.");
	}
	
	void Update()
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
