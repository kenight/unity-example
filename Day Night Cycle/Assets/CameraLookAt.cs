using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

	public Transform target;

	void LateUpdate() {
		transform.LookAt(new Vector3(target.position.x, 0, target.position.z));
	}
}