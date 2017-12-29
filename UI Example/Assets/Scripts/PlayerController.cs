using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5;
	public float maxSpeed = 10;
	public float power = 500;
	public GameObject bulletPrefab;
	public bool controlled = true;

	private Transform cannon;
	private Transform spawnPoint;
	private Rigidbody2D rbody;

	void Start() {
		cannon = transform.Find("Body/Cannon");
		spawnPoint = transform.Find("Body/Cannon/SpawnPoint");
		rbody = GetComponent<Rigidbody2D>();
	}

	// Apply to MoveButton
	public void Move(bool toRight) {
		if (!controlled)
			return;

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
		if (!controlled)
			return;

		cannon.localRotation = Quaternion.Euler(0, 0, -angle);
	}

	// Apply to Fire Button
	public void Fire(float factor) {
		if (!controlled)
			return;

		PhotonView.Get(this).RPC("SpawnBullet", PhotonTargets.All, factor);

		// Instantiate networked gameObject
		// GameObject _bullet = PhotonNetwork.Instantiate(bulletPrefab.name, spawnPoint.position, Quaternion.identity, 0);
		// _bullet.GetComponent<Rigidbody2D>().AddForce(cannon.right * power * factor);
	}

	[PunRPC]
	void SpawnBullet(float factor) {
		GameObject _bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
		_bullet.GetComponent<Rigidbody2D>().AddForce(cannon.right * power * factor);
	}

}