using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	bool isDynamic = false;

	Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if (isDynamic == false && Input.GetKeyUp(KeyCode.Space)) {
			rb.bodyType = RigidbodyType2D.Dynamic;
			isDynamic = true;
		}
	}

}