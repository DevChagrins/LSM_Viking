using UnityEngine;

public class Controller_KeyJoy : MonoBehaviour
{
	// Controls, used mostly for joysticks on controllers to keep them from moving about randomly
	public float calibrationXMin;
	public float calibrationXMax;
	public float calibrationYMin;
	public float calibrationYMax;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	// Handles calibration values as well as making sure it doesn't go over a certain value
	public void ClampInput(ref float verticalInput, ref float horizontalInput)
	{
		if ((verticalInput >= calibrationXMin) && (verticalInput <= calibrationXMax))
			verticalInput = 0;

		if ((horizontalInput >= calibrationYMin) && (horizontalInput <= calibrationYMax))
			horizontalInput = 0;

		verticalInput = Mathf.Min(verticalInput, 1.0f);
		horizontalInput = Mathf.Min(horizontalInput, 1.0f);

		verticalInput = Mathf.Max(verticalInput, -1.0f);
		horizontalInput = Mathf.Max(horizontalInput, -1.0f);
	}
}
