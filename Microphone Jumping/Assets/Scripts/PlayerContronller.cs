using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContronller : MonoBehaviour {

	public float jumpForce = 500;
	public float jumpTime = 2f;
	public float moveForce = 100;
	public float maxSpeed = 2f;

	private Rigidbody2D rig;
	private float timer = 0;

	void Awake() {
		rig = GetComponent<Rigidbody2D>();
	}

	void Update() {
		Move();
		Jump();
	}

	void Jump() {
		if (MicrophoneInput.volume > 0.4 && Time.time - timer > jumpTime) {
			rig.AddForce(Vector2.up * jumpForce * MicrophoneInput.volume);
			timer = Time.time;
		}
	}

	void Move() {
		if (MicrophoneInput.volume > 0.1) {
			rig.AddForce(Vector2.right * moveForce);
			rig.velocity = new Vector2(Mathf.Clamp(rig.velocity.x, 0, maxSpeed), rig.velocity.y);
		}
	}
}