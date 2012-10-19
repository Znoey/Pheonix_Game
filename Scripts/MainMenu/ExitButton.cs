using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InputMessageDispatch.instance.Create();
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown("escape"))
		{
			Application.Quit();
		}
	}
	
	public void MsgClick(InputInfo info)
	{
		Application.Quit();
	}
}
