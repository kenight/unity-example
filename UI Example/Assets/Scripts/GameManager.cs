using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public PlayerPrefsSo playerPrefs;
	public string playerName;
	public int playerIndex;

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