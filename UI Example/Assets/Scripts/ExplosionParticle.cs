﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour {

	private ParticleSystem ps;

	void Start() {
		ps = GetComponent<ParticleSystem>();
		Destroy(gameObject, ps.main.duration);
	}
}