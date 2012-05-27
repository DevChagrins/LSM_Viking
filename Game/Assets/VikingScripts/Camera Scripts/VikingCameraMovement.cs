using UnityEngine;
using System.Collections;

/// <summary>
/// VikingCameraMovement
/// ---------------------------------------------------------
/// Author: Malcolm Gruber
/// =========================================================
/// Purpose: Controls the third person camera limited to half
///     sphere movement.
/// =========================================================
/// Notes:
/// ---------------------------------------------------------
/// </summary>


public class VikingCameraMovement : MonoBehaviour 
{
    // Camera information
    private Vector3 cameraPositionOld;
    private Vector3 cameraPositionNew;
    public Vector3 cameraPositionCurrent;

    public float cameraOffsetY;
	public float cameraDistanceMax;
	public float cameraDistanceMin;
	public float cameraDistance;

	public Vector3 rotationMax;
	public Vector3 rotationMin;
	public Vector3 rotationVector;

	private Quaternion cameraRotation;

	public float cameraSpeedX;
	public float cameraSpeedY;
	public float cameraSpeedZ;

    // Player Informations
    public Transform playerTransform;

	// Use this for initialization
	void Start() 
	{
		// Save the old camera position
		cameraPositionOld = cameraPositionCurrent;

		// Move the camera before we rotate it
		gameObject.transform.position = playerTransform.position;

		// Do the rotations
		CameraRotate();

		// Grab the new position
		cameraPositionCurrent = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update() 
	{
		// Save the old camera position
		cameraPositionOld = cameraPositionCurrent;

		// Grab the new position for the camera
        cameraPositionNew = playerTransform.position;
		gameObject.transform.position = cameraPositionNew;

		// Do the rotations
		CameraRotate();

		// Grab the new position
		cameraPositionCurrent = cameraPositionNew;
	}

	void CameraRotate()
	{
		if (Input.GetMouseButton(1))
		{
			rotationVector.x += (Input.GetAxis("Mouse X") * 100) * cameraSpeedX * Time.deltaTime;
			rotationVector.y += (Input.GetAxis("Mouse Y") * -100) * cameraSpeedY * Time.deltaTime;
		}

		cameraDistance += (Input.GetAxis("Mouse ScrollWheel") * 100) * cameraSpeedZ * Time.deltaTime;
		cameraDistance = ClampValue(cameraDistance, cameraDistanceMin, cameraDistanceMax);

		rotationVector.y = ClampValue(rotationVector.y, rotationMin.y, rotationMax.y);

		// Calculate the rotation
		cameraRotation = Quaternion.Euler(rotationVector.y, rotationVector.x, 0);

		// Calculate the offset
		Vector3 offSet = new Vector3(0.0f, cameraOffsetY, -cameraDistance);

		// Move the camera position
		Vector3 position = cameraRotation * offSet + playerTransform.position;

		// Set all of the values
		transform.rotation = cameraRotation;
		transform.position = position;

		cameraRotation = gameObject.transform.rotation;
	}

	float ClampValue(float value, float min, float max)
	{
		if (value > max)
		{
			value = max;
		}

		if (value < min)
		{
			value = min;
		}

		return value;
	}

	bool TerrainHeightClamp(Vector3 cameraPosition, Vector3 cameraForward, out Vector3 newCameraPosition)
	{
		newCameraPosition = new Vector3(0, 0, 0);
		return true;
	}
}
