using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float startOffset = 1f;

	TheStackPool pool;
	float originCamY, topStackY;

	void Start() {
		pool = TheStackPool.instance;
		originCamY = transform.position.y;
	}

	void LateUpdate() {
		topStackY = pool.FirstStack().transform.position.y;
		if (topStackY - startOffset < 0)
			return;
		else
			topStackY -= startOffset;
		Vector3 newPos = new Vector3(transform.position.x, originCamY + topStackY, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 5f);
	}
}