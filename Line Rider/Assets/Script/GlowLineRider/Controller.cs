using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float speed = 10f;
	public float rotatePower = 5f;

	Rigidbody2D rb;
	bool moving = false, isGround = false;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space))
			moving = true;

		if (Input.GetKeyUp(KeyCode.Space))
			moving = false;
	}

	void FixedUpdate() {
		if (moving) {
			if (isGround)
				rb.AddForce(transform.right * speed);
			else
				rb.AddTorque(rotatePower);
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		isGround = true;
	}

	private void OnCollisionExit2D(Collision2D other) {
		isGround = false;
	}
}