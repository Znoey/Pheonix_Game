using UnityEngine;
using System.Collections;


/// <summary>
/// Message dispatch will send messages based on the input events like enter, exit, click.
/// </summary>
public sealed class InputMessageDispatch : UnitySingleton<InputMessageDispatch> {
	
	
	public Camera raycastCamera;
	public float clickTimeThreshhold = 0.2f;
	private Ray ray;
	private RaycastHit hit;
	private bool didHitObject = false;
	public int Button {get; set;}
	public GameObject LastHit {get; set;}
	public GameObject CurrentHit {get; set;}
	public GameObject CurrentDown {get; set;}
	public float TimeFirstDown {get; set;}
	
	public void Start()
	{
		LastHit = null;
		CurrentHit = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(raycastCamera == null )
		{
			raycastCamera = Camera.mainCamera;
			if(raycastCamera == null )
			{
				raycastCamera = Camera.allCameras[0];
			}
		}
		CurrentHit = null;
		ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
		didHitObject = Physics.Raycast(ray, out hit);
		Button = (int)MouseButton.None;
		
		if( Input.GetMouseButtonDown(0)){
			Button |= (int)MouseButton.Left;
			//Button &= ~(int)MouseButton.None;
			TimeFirstDown = Time.time;
		}
		if( Input.GetMouseButtonDown(1)){
			Button |= (int)MouseButton.Right;
			//Button &= ~(int)MouseButton.None;
			TimeFirstDown = Time.time;
		}
		if( Input.GetMouseButtonDown(2)){
			Button |= (int)MouseButton.Middle;
			//Button &= ~(int)MouseButton.None;
			TimeFirstDown = Time.time;
		}
		if(Input.GetMouseButtonUp(0)){
			Button &= ~(int)MouseButton.Left;
			Button &= ~(int)MouseButton.None;
		}
		if(Input.GetMouseButtonUp(1)){
			Button &= ~(int)MouseButton.Right;
			Button &= ~(int)MouseButton.None;
		}
		if(Input.GetMouseButtonUp(2)){
			Button &= ~(int)MouseButton.Middle;
			Button &= ~(int)MouseButton.None;
		}
		
		if( didHitObject )
		{
			//Debug.Log(this.name + " Hit Object", this);
			CurrentHit = hit.collider.gameObject;
			if( (Button & (int)MouseButton.Left) != 0  )//|| (Button & (int)MouseButton.Right) != 0 || (Button & (int)MouseButton.Middle) != 0)
			{
				CurrentDown = CurrentHit;
				SendMsg(CurrentHit, InputMessage.MsgDown);
			}
			if( (Button & (int)MouseButton.None) == 0 && CurrentHit != null & CurrentHit == LastHit)
			{
				SendMsg(CurrentHit, InputMessage.MsgUp);
			}
			
			if( LastHit == null )
			{
				SendMsg(CurrentHit, InputMessage.MsgEnter);
			}
			
			if( (Button & (int)MouseButton.None) == 0 && (Button & (int)MouseButton.Left) == 0 && CurrentHit == LastHit &&
				Time.time - TimeFirstDown <= clickTimeThreshhold)
			{
				SendMsg(CurrentHit, InputMessage.MsgClick);
			}
		}
		
		if( !didHitObject && LastHit != null)
		{
			SendMsg(LastHit, InputMessage.MsgExit);
		}
		
		LastHit = CurrentHit;
	}
	
	private void SendMsg(GameObject go, InputMessage msg)
	{
		go.SendMessage(msg.ToString(), new InputInfo(msg, Button), SendMessageOptions.DontRequireReceiver);
	}
}


public enum InputMessage {
	NONE,
	MsgEnter,
	MsgExit,
	MsgDown,
	MsgUp,
	MsgClick,
	MsgHover,
}

[System.Flags]
public enum MouseButton
{
	Left = 0x01,
	Right = 0x02,
	Middle = 0x04,
	None = 0x08,
}

public sealed class InputInfo
{
	public InputMessage msg;
	public int btn;
	
	public InputInfo(InputMessage _msg, int _mouseButton)
	{
		msg = _msg;
		btn = _mouseButton;
	}
}
