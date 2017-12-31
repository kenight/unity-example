using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Photon.PunBehaviour {

	public int hp = 100;
	public RectTransform hpBar;
	public RectTransform hpProgress;
	public RespawnTime respawnTime;

	private PlayerSpawnPoints playerSpawnPoints;
	private Animator playerAnim;
	private PlayerManager playerManager;

	void Awake() {
		playerAnim = GetComponent<Animator>();
		playerSpawnPoints = FindObjectOfType<PlayerSpawnPoints>();
	}

	[PunRPC]
	public void TakeDamage(int damage) {
		hp -= damage;
		playerAnim.SetTrigger("Damage");

		if (hp < 0) {
			hp = 0;
			Dead();
		}
		UpdateHpBar();
	}

	void UpdateHpBar() {
		// hpProgress 全长只有 1 , 所以乘以系数 0.01
		hpProgress.sizeDelta = new Vector2(hpBar.sizeDelta.x * hp * 0.01f, hpProgress.sizeDelta.y);
	}

	void Dead() {
		playerAnim.SetBool("Dead", true);
		// 修改 Layer 忽略碰撞
		gameObject.layer = LayerMask.NameToLayer("Dead");
		// 禁用玩家控制
		GetComponent<PlayerController>().controlled = false;
		// 重生
		StartCoroutine(Respawn());
	}

	public IEnumerator Respawn() {
		// 显示倒计时
		respawnTime.gameObject.SetActive(true);
		yield return new WaitForSeconds(respawnTime.deadTime); // 倒计时后开始重置
		respawnTime.gameObject.SetActive(false);
		// 重置状态
		playerAnim.SetBool("Dead", false);
		hp = 100;
		UpdateHpBar();
		transform.position = playerSpawnPoints.pos[Random.Range(0, playerSpawnPoints.pos.Length)].position;
		gameObject.layer = LayerMask.NameToLayer("Player");
		GetComponent<PlayerController>().controlled = true;
	}

}