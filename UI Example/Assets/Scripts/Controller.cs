using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float speed = 5;
	public float maxSpeed = 10;
	public float power = 500;
	public GameObject target;
	public GameObject bullet;

	private Transform cannon;
	private Transform spawnPoint;
	private Rigidbody2D rbody;

	void Awake() {
		cannon = target.transform.Find("Body/Cannon");
		spawnPoint = target.transform.Find("Body/Cannon/SpawnPoint");
		rbody = target.GetComponent<Rigidbody2D>();
	}

	// Apply to MoveButton
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

	// Apply to Aim Slider
	public void Aim(float angle) {
		cannon.localRotation = Quaternion.Euler(0, 0, -angle);
	}

	// Apply to Fire Button
	public void Fire(float factor) {
		GameObject _bullet = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
		_bullet.GetComponent<Rigidbody2D>().AddForce(cannon.right * power * factor);
	}

}