using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	public ObjectPool cubePool;

	void FixedUpdate() {
		float xPos = Random.Range(transform.position.x - 1, transform.position.x + 1);
		float zPos = Random.Range(transform.position.z - 1, transform.position.z + 1);
		Vector3 pos = new Vector3(xPos, transform.position.y, zPos);
		GameObject go = cubePool.InstantiateFromPool(pos, Quaternion.identity);
		go.GetComponent<Cube>().OnInstantiated();
	}
}