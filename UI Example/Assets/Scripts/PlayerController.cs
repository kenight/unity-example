using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Photon.PunBehaviour {

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

		// 射击流程及命中检测方案
		// 由攻击者本地上报发射事件，即这里的 Fire
		// 由 RPC 广播并在所有客户端同步创建子弹
		// 攻击者客户端检测命中并应用伤害
		// 其他客户端预表现，但不应用伤害(否则重复计算伤害)
		// 子弹是客户端本地创建，并未参与同步，所以记录下攻击者 actId, 用于判断在攻击者客户端应用伤害

		// RPC 所有客户端同步创建子弹
		PhotonView.Get(this).RPC("SpawnBullet", PhotonTargets.All, factor, photonView.owner);
	}

	[PunRPC]
	void SpawnBullet(float factor, PhotonPlayer sender) {
		GameObject _bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
		_bullet.GetComponent<Bullet>().sender = sender;
		_bullet.GetComponent<Rigidbody2D>().AddForce(cannon.right * power * factor);
	}

}