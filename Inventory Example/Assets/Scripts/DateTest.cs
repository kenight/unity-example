using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DateTest : MonoBehaviour {

	void Start() {
		ItemData itemDate = ItemData.get();
		Debug.Log(itemDate.total);
	}

}