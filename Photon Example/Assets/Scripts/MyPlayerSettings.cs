using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 该类作用是在不同场景中传递数据
public class MyPlayerSettings : MonoBehaviour {

	public static MyPlayerSettings instance;
	public int spriteIndex = 0;

	void Awake() {
		if (instance) {
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

}