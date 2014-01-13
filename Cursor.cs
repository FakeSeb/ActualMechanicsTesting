using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

	public Vector2 Position;
	private Vector2 OldMousePosition;
	public Vector2 DeltaPosition;



	// Use this for initialization
	void Start () {
		Position = new Vector2(0,0);
		OldMousePosition = new Vector2(0,0);
		DeltaPosition = new Vector2(0,0);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		DeltaPosition = MousePosition - OldMousePosition;
		Position += DeltaPosition;
		OldMousePosition = MousePosition;
	
	}
}
