

using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Custom Mouse Look")]
public class CustomMouseLook : MonoBehaviour
{
	// Zoom factor determines how far the camera zooms based on the relative distance of the mouse from the center of the screen. Represented by the size of the screen (0.5 = Half of the screen).
	public float zoomFactorX = 10.0f;
	public float zoomFactorY = 10.0f;
	// --
	public float invertX = -1.0f;
	public float invertY = -1.0f;
	// Smooth factor determines how fast or slow the camera arrives to its destination. Represented by the current distance from the destination (10 = 1/10th of the distance to destination).
	public float smoothFactor = 10.0f;
	// Tilt rate determines how much the camera tilts on its journey to the destination. Represented as the max angle the camera will tilt when moving across the sc :TODO
	public float tiltRate = 30.0f;
	
	// Static variables
	public GameObject targetObject;
	public Vector3 Position = new Vector3(0, 0, 0);
	public Vector3 mousePosition;
	public Vector3 deltaPosition;
	public Vector2 deltaMouse;
	
	public float movementX = 0.0f;
	public float movementY = 0.0f;
	
	Vector3 initialPosition;
	Vector3 initialRotation;
	
	// Initialize things
	void Start()
	{
		initialPosition = transform.localPosition;
		initialRotation = new Vector3(60.0f, 0.0f, 0.0f);
	}
	
	// Update things
	void Update()
	{
		// Get the target position
		mousePosition = new Vector3(Mathf.Clamp(2.0f * (0.5f - Input.mousePosition.x / Screen.width), -1.0f, 1.0f), Mathf.Clamp(2.0f * (0.5f - Input.mousePosition.y / Screen.height), -1.0f, 1.0f), 0.0f);
		
		// Get the delta position
		deltaPosition = (mousePosition - Position) / smoothFactor;
		
		// Update the position
		Position += deltaPosition;
		
		// Set the transforms
		transform.localEulerAngles = initialRotation + new Vector3(deltaPosition.y * tiltRate, 0.0f, deltaPosition.x * tiltRate);
		transform.localPosition = targetObject.transform.localPosition + new Vector3(Position.x * zoomFactorX * invertX, 0.0f, Position.y * zoomFactorY * invertY) + initialPosition;
	}
}

