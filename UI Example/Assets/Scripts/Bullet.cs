using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damage = 10;
	public float lifeTime = 3;

	void Start() {
		Destroy(gameObject, lifeTime);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
		}
	}

}