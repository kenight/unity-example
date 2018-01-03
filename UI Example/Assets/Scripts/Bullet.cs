using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Photon.PunBehaviour {

	public int damage = 10;
	public float lifeTime = 3;
	public ParticleSystem explosionPrefab;
	[HideInInspector]
	public PhotonPlayer sender;

	void Start() {
		Destroy(gameObject, lifeTime);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			// 碰撞后预表现效果
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			// Destory
			Destroy(gameObject);

			// 命中检测方案
			// 发送者客户端检测命中并应用伤害
			// 其他客户端预表现，但不应用伤害
			// 子弹是客户端本地创建，并未参与同步，所以记录下攻击者 actId, 用于判断在攻击者客户端应用伤害

			if (PhotonNetwork.player.ID != sender.ID)
				return;
			// 应用伤害
			PhotonView pv = other.gameObject.GetComponent<PhotonView>();
			pv.RPC("TakeDamage", PhotonTargets.All, damage);
		}
	}

}