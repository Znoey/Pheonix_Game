using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		InputMessageDispatch.instance.Create();
	}
	
	public void MsgClick(InputInfo info)
	{
		Debug.Log("Start Game.");
		GameManager.instance.ChangeState(new GameState(GameManager.instance));
	}
}
