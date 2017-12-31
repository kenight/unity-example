using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnTime : MonoBehaviour {

	public int deadTime = 5;
	private Text textObject;
	private float timer;

	void Awake() {
		textObject = GetComponent<Text>();
	}

	void OnEnable() {
		timer = deadTime;
		textObject.text = deadTime.ToString("0");
	}

	void Update() {
		if (timer > 0) {
			timer -= Time.deltaTime;
			textObject.text = timer.ToString("0");
		}
	}
}