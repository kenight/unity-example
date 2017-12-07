using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour {

	[Range(1, 10)]
	public float boost = 1;
	public static float volume;
	private int sampleLength = 128;
	private AudioClip recordClip;
	private string device;

	void Awake() {
		device = Microphone.devices[0];
	}

	void Start() {
		Microphone.End(device);
		recordClip = Microphone.Start(device, true, 300, 44100);
	}

	void Update() {
		volume = GetMaxVolume() * boost;
	}

	// 利用 Microphone.GetPosition 获得当前进度，往前计算一段 sample 数据，找出一个峰值代表这段时间的音量大小
	float GetMaxVolume() {
		float[] samples = new float[sampleLength];

		int pos = Microphone.GetPosition(device);
		int offset = pos - sampleLength + 1;

		if (offset < 0)
			return 0;

		recordClip.GetData(samples, offset);

		float max = 0;
		for (int i = 0; i < sampleLength; i++) {
			float v = samples[i];
			if (v > max)
				max = v;
		}
		return max;
	}
}