using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public PlayerPrefsSo playerPrefs;
	public string playerName;

	void Awake() {
		if (instance) {
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
			// Init preference
			playerName = playerPrefs.playerName;
		}
	}

}