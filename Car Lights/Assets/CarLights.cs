using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour {

	public MeshRenderer brakeLights;
	public Material brakeLightOn;
	public Material brakeLightOff;

	public MeshRenderer headLights;
	public Material headLightOn;
	public Material headLightOff;
	public Light SpotlightLeft;
	public Light SpotlightRight;

	public MeshRenderer turnSignalLeft;
	public MeshRenderer turnSignalRight;
	public Material turnSignalOn;
	public Material turnSignalOff;
	public bool turnSignalLeftOn = false;
	public bool turnSignalRightOn = false;

	void Start() {

	}

	void Update() {
		// brake light
		if (Input.GetKey(KeyCode.S))
			brakeLights.material = brakeLightOn;
		else
			brakeLights.material = brakeLightOff;

		// head light
		if (Input.GetKey(KeyCode.W)) {
			headLights.material = headLightOn;
			SpotlightLeft.intensity = 2;
			SpotlightRight.intensity = 2;
		} else {
			headLights.material = headLightOff;
			SpotlightLeft.intensity = 0;
			SpotlightRight.intensity = 0;
		}

		// Turn Left light
		if (Input.GetKey(KeyCode.A)) {
			turnSignalLeft.material = turnSignalOn;
			turnSignalLeftOn = true;
		} else {
			turnSignalLeft.material = turnSignalOff;
			turnSignalLeftOn = false;
		}

		// Turn Right light
		if (Input.GetKey(KeyCode.D)) {
			turnSignalRight.material = turnSignalOn;
			turnSignalRightOn = true;
		} else {
			turnSignalRight.material = turnSignalOff;
			turnSignalRightOn = false;
		}

		// 开启时闪烁
		if (turnSignalLeftOn) {
			// 让 Time.time 永远在 0 到 0.4 之间往返 (第一个参数一定是增长或减少的变动的数)
			float emission = Mathf.PingPong(Time.time, 0.4f);
			turnSignalLeft.material.SetColor("_EmissionColor", new Color(1, 1, 1) * emission);
		}

		if (turnSignalRightOn) {
			float emission = Mathf.PingPong(Time.time, 0.4f);
			turnSignalRight.material.SetColor("_EmissionColor", new Color(1, 1, 1) * emission);
		}

	}
}