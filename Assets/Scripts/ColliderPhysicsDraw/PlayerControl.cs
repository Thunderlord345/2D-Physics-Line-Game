using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    private Player player; // Reference to the player controller
 	private Vector3 move; // World-relative desired move direction, calculated from user input
	bool jump = false; // Check if jump button is pressed

	void Awake() {
		player = GetComponent<Player>();
	}
	
	void Update() {
		jump = Input.GetButton("Jump");
		float h = Input.GetAxis("Horizontal");
		move = (h * Vector3.right).normalized;
	}

	void FixedUpdate() {
		player.Move(move, jump);
	}

	public void ResetPlayerPosition() {
		transform.position = new Vector3(0, 8, 0);
		transform.rotation = Quaternion.identity;
	}
}