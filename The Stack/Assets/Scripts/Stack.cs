using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour {

	public Vector3 stackScale;

	void Start() {
		transform.localScale = stackScale;
	}

	public float SingleHeight() {
		return stackScale.y;
	}
}