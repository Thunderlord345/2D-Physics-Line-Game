using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[DisallowMultipleComponent]
public class Vehicle : MonoBehaviour
{
	public Vector2 maxSpeed;
	private Vector2 tempVector;
	private Rigidbody2D rigidBody2D;
	public bool moveOnStart;
	private string uiSpeedPrefix = "Speed :";
	private ConstantForce2D[] wheelsForces;

	void Awake(){
		rigidBody2D = GetComponent<Rigidbody2D> ();
		wheelsForces = GetComponentsInChildren<ConstantForce2D> ();
		if (moveOnStart) {
			Move ();
		} else {
			Stop ();
		}
	}

	void FixedUpdate ()
	{
		tempVector = rigidBody2D.velocity;
		tempVector.x = Mathf.Clamp (tempVector.x, -Mathf.Infinity, maxSpeed.x);
		tempVector.y = Mathf.Clamp (tempVector.y, -Mathf.Infinity, maxSpeed.y);
		rigidBody2D.velocity = tempVector;
		SetUISpeed ();
	}

	public void Move ()
	{
		foreach (ConstantForce2D force in wheelsForces) {
			force.enabled = true;
		}
	}

	public void Stop ()
	{
		foreach (ConstantForce2D force in wheelsForces) {
			force.enabled = false;
		}
	}

	public void SetUISpeed(){
		if (UIManager.instance.vechicleSpeed != null) {
			UIManager.instance.vechicleSpeed.text = uiSpeedPrefix+String.Format("{0:0.0#}",  rigidBody2D.velocity.magnitude);
		}
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Target")
        {
            GameObject.Find("YouWonText").GetComponent<Text>().enabled = true;
        }
    }
}