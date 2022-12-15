using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float movePower = 5f; // Force added to the ball to move it
	public bool useTorque = false; // To use or not to use torque for drivinb the rolling object
	public float maxAngularVelocity = 5f; // Maximum angular velocity at which rolling object can rotate
	public float jumpPower = 50f; // Force added to the ball when it jumps
    private float groundRayLength = 0.1f; // Length of the ray to check if the ball is grounded
	
    void Start() {
		GetComponent<Rigidbody2D>().angularVelocity = maxAngularVelocity; // Set maximum angular velocity
	}

	void Update() {
		Debug.DrawRay(transform.position, -Vector2.up, Color.blue, groundRayLength);
	}

	public void Move(Vector3 moveDirection, bool jump) {
		if(useTorque) // If using torque to rotate the rolling object
			// Add torque around the axis defined by the move direction
			// Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * movePower);
			GetComponent<Rigidbody2D>().AddTorque(movePower);
		else
			// Otherwise add force in the move direction
			GetComponent<Rigidbody2D>().AddForce(moveDirection * movePower);

		// If grounded and jump is pressed
		if(Physics2D.Raycast(transform.position, -Vector2.up, groundRayLength) && jump) {
			// Add upward force
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower, ForceMode2D.Force);
		}
	}
}