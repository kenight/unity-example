using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	private void OnMouseDown() {
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90);
	}

}