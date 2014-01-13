using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public GameObject Other;

	private Cursor CursorCall;
	private float Mode;

	void Awake ()
	{
		CursorCall = Other.GetComponent<Cursor>();

	}

	// Use this for initialization
	void Start () {
		//Debug.Log (CursorCall.DeltaPosition.x);
		Mode = 0;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		bool held = Input.GetButton("Switch");
		
		bool down = Input.GetButtonDown("Toggle");
		//bool up = Input.GetButtonUp("Jump");
		float SwitchMode;
		if(down)
		{
			if(Mode==0) 
			Mode = 1; 
			else Mode = 0;
		}
		if(held)
		{
			if(Mode==0) SwitchMode = 1;
			else SwitchMode=0;
		}
		else 
		{ 
			SwitchMode = Mode;
		}

		float NotSwitchMode;

		if(SwitchMode==0)
		{
			NotSwitchMode = 1;
		}
		else 
		{
			NotSwitchMode=0;
		}

		Vector3 Movement = new Vector3 (CursorCall.DeltaPosition.y*NotSwitchMode,CursorCall.DeltaPosition.y*SwitchMode,-CursorCall.DeltaPosition.x);
		rigidbody.AddForce (Movement * 2);




	}
}
