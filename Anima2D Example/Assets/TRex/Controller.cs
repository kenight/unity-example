using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {
		float xAixs = Input.GetAxis("Horizontal");

		Vector3 eulerAngles = transform.localEulerAngles;

		if (xAixs < 0)
			eulerAngles.y = 180;
		else if (xAixs > 0)
			eulerAngles.y = 0;

		transform.localRotation = Quaternion.Euler(eulerAngles);

		animator.SetFloat("Speed", Mathf.Abs(xAixs));
	}
}