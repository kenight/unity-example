using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

	public InputField input;

	void Start() {
		input.text = GameManager.instance.playerName;
	}

	public void PlayNow() {
		if (input.text.Trim().Length > 0) {
			// Set name
			GameManager.instance.playerName = input.text;
			GameManager.instance.playerPrefs.playerName = input.text;
			// Load scene
			SceneManager.LoadScene(1);
		}
	}

	public void SelectPlayer(int index) {
		GameManager.instance.playerIndex = index;
	}

}