using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InputMessageDispatch.instance.Create();
	}
	
	/*
	
	MsgEnter,
	MsgExit,
	MsgDown,
	MsgUp,
	MsgClick,
	MsgHover,
	
	*/
	
	public void MsgEnter(InputInfo info)
	{
		Debug.Log("PlayButton ENTER.");
	}
	public void MsgExit(InputInfo info)
	{
		Debug.Log("PlayButton EXIT.");
	}
	public void MsgDown(InputInfo info)
	{
		Debug.Log("PlayButton DOWN.");
	}
	public void MsgUp(InputInfo info)
	{
		Debug.Log("PlayButton UP.");
	}
	public void MsgClick(InputInfo info)
	{
		Debug.Log("PlayButton CLICK.");
	}
}
