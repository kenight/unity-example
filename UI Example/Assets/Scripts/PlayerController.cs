using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5;
	public float maxSpeed = 10;
	public GameObject cannon;

	private Rigidbody2D rbody;

	void Awake() {
		rbody = GetComponent<Rigidbody2D>();
	}

	// Apply to OnPressedButton.cs
	public void Move(bool toRight) {
		Vector2 direction = Vector2.zero;
		if (toRight)
			direction = Vector2.right;
		else
			direction = Vector2.left;

		float xSpeed = speed * Time.deltaTime * 100;
		float maxXspeed = maxSpeed * Time.deltaTime * 100;

		rbody.AddForce(direction * xSpeed);

		// Max speed
		if (xSpeed > maxXspeed)
			rbody.velocity = direction * maxXspeed;
	}

	// Apply to Slider
	public void Aim(float angle) {
		cannon.transform.localRotation = Quaternion.Euler(0, 0, -angle);
	}

}