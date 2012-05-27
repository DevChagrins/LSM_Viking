using UnityEngine;
using System.Collections;

public class Controller_Mouse : MonoBehaviour 
{
	// Positions and Deltas
	public Vector3 mousePositionScreen;
	public Vector3 mousePositionWorld;
	public Vector3 mouseDeltaScreen;
	public Vector3 mouseDeltaWorld;

	// External Game Objects
	public Transform playerTransform;
	public Camera cameraObject;

	// Use this for initialization
	void Start() 
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		// Grab screen position of the mouse
		mousePositionScreen = Input.mousePosition;

		// Get the mouse delta with screen position
		mouseDeltaScreen.x = (mousePositionScreen.x - ((float)Screen.width / 2)) / ((float)Screen.width / 2);
		mouseDeltaScreen.y = (mousePositionScreen.y - ((float)Screen.height / 2)) / ((float)Screen.height / 2);
	
		// Mouse screen to world
		mousePositionScreen.z = cameraObject.transform.position.y;
		mousePositionWorld = cameraObject.ScreenToWorldPoint(mousePositionScreen);

		// World mouse delta
		mouseDeltaWorld.x = mousePositionWorld.x + playerTransform.position.x;
		mouseDeltaWorld.z = mousePositionWorld.z - playerTransform.position.z;
	}
}
