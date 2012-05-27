using UnityEngine;
using System.Collections;

public class VikingController : MonoBehaviour {

	public float playerWalkSpeed;
	public float playerRunSpeed;
	public float playerTurnSpeed;

	public float playerGravity;

	public Vector3 playerOldForward;
	public Vector3 playerNewForward;
	public Vector3 playerCurrentForward;

	private Vector3 playerMoveDirection;

	private CollisionFlags collidedFlags;
	private bool playerMoving;

	public Transform cameraTransform;

	private Controller_KeyJoy controllerKeyboardJoystick;
	private CharacterController characterController;

	// Use this for initialization
	void Start() 
	{
		// Default player moving to rue
		playerMoving = true;
		
		// Get the keyboard/joystick input object
		characterController = GetComponent<CharacterController>();
		controllerKeyboardJoystick = GameObject.Find("__ControllerInterface").GetComponent<Controller_KeyJoy>();

		// Get input and cap it
		float vert = Input.GetAxisRaw("Vertical");
		float horz = Input.GetAxisRaw("Horizontal");

		// Clamp input
		controllerKeyboardJoystick.ClampInput(ref vert, ref horz);

		// Do a moving check
		if ((vert == 0) && (horz == 0))
		{
			playerMoving = false;
		}
		else
		{
			playerMoving = true;	
		}
		
		// Save the current forward vector
		playerOldForward = playerCurrentForward;
		
		if( playerMoving == true )
		{
			// Get the forward vector of the camera
			playerNewForward = cameraTransform.TransformDirection(Vector3.forward);	
		}
		else
		{
			playerNewForward = playerCurrentForward;	
		}
	
		playerNewForward.y = 0;
		playerNewForward = playerNewForward.normalized;

		Vector3 playerRight = new Vector3(playerNewForward.z, 0, -playerNewForward.x);

		// Update the direction the player is moving
		playerCurrentForward = (horz * playerRight) + (vert * playerNewForward);

		// Calculate the target speed
		float playerTargetSpeed = playerRunSpeed;

		playerMoveDirection = playerCurrentForward.normalized * playerTargetSpeed;
		playerMoveDirection = ApplyGravity(playerMoveDirection);
		Vector3 playerMovement = playerMoveDirection * Time.deltaTime;

		collidedFlags = characterController.Move(playerMovement);

		gameObject.transform.rotation = Quaternion.LookRotation(playerCurrentForward.normalized);
	}
	
	// Update is called once per frame
	void Update()
	{
		// Get input and cap it
		float vert = Input.GetAxisRaw("Vertical");
		float horz = Input.GetAxisRaw("Horizontal");

		// Clamp input
		controllerKeyboardJoystick.ClampInput(ref vert, ref horz);

		// Do a moving check
		if ((vert == 0) && (horz == 0))
		{
			playerMoving = false;
		}
		else
		{
			playerMoving = true;	
		}
		
		// Save the current forward vector
		playerOldForward = playerCurrentForward;
		
		// If the players moving, do it normally, if not keep him facing the same direction
		if( playerMoving == true )
		{
			// Get the forward vector of the camera
			playerNewForward = cameraTransform.TransformDirection(Vector3.forward);
		}
		else
		{
			// Set the new forward to the current one
			playerNewForward = playerCurrentForward;
			vert = 1;
		}
	
		// Make sure he's not moving up and down
		playerNewForward.y = 0;
		playerNewForward = playerNewForward.normalized;
		
		// Calculate the player's right vector
		Vector3 playerRight = new Vector3(playerNewForward.z, 0, -playerNewForward.x);

		// Update the direction the player is moving
		playerCurrentForward = (horz * playerRight) + (vert * playerNewForward);

		// Calculate the target speed
		float playerTargetSpeed = playerRunSpeed;
		
		if( playerMoving == false )
		{
			playerTargetSpeed = 0.0f;	
		}
		
		// Calcuate the move direction by adding the target speed and apply gravity
		playerMoveDirection = playerCurrentForward.normalized * playerTargetSpeed;
		playerMoveDirection = ApplyGravity(playerMoveDirection);
		Vector3 playerMovement = playerMoveDirection * Time.deltaTime;

		collidedFlags = characterController.Move(playerMovement);

		gameObject.transform.rotation = Quaternion.LookRotation(playerCurrentForward.normalized);
	}

	// Call this update to move the player
	void LateUpdate()
	{
		
	}

	Vector3 ApplyGravity(Vector3 movement)
	{
		movement.y = playerGravity * 6.0f;

		return movement;
	}
}
