using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour {

	public float volume;
	private AudioClip recordClip;
	private string device;

	void Awake() {
		device = Microphone.devices[0];
	}

	void Start() {
		recordClip = Microphone.Start(device, true, 300, 44100);
	}

	void Update() {
		volume = GetVolume();
	}

	float GetVolume() {
		float[] samples = new float[1];
		// 每帧从 recordClip 的当前位置采样并填充到 samples 数组，采样的值是一个 -1 到 1 的浮点数
		recordClip.GetData(samples, Microphone.GetPosition(device));
		return samples[0];
	}
}