using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour {

	[HideInInspector]
	public bool isEmpty = true;
	public GameObject stuffPrefab;

	private void OnMouseDown() {
		if (isEmpty) {
			Instantiate(stuffPrefab, transform.position, Quaternion.Euler(0, 0, 135), transform);
			isEmpty = false;
		} else {
			Debug.Log("Already have one");
		}

	}

}