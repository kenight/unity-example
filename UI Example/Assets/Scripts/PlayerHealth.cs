using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int hp = 100;
	public RectTransform hpBar;
	public RectTransform hpProgress;

	private Animator playerAnim;

	void Awake() {
		playerAnim = GetComponent<Animator>();
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
	}

}