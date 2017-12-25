using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

	public InputField inputField;
	public LobbyManager lobbyManager;

	private string _inputValue;

	void Start() {
		inputField.text = GameManager.instance.playerName;
	}

	public void PlayNow() {
		_inputValue = inputField.text;

		if (inputField.text.Trim().Length > 0) {
			// Set name
			GameManager.instance.playerName = _inputValue;
			GameManager.instance.playerPrefs.playerName = _inputValue;
			PhotonNetwork.playerName = _inputValue;

			// Join or create a room
			lobbyManager.JoinRoom();
		}
	}

	public void SelectPlayer(int index) {
		GameManager.instance.playerIndex = index;
	}

}