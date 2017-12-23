﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damage = 10;
	public float lifeTime = 3;
	public ParticleSystem explosionPrefab;

	void Start() {
		Destroy(gameObject, lifeTime);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			// Take damage
			other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
			// Explosion
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

}