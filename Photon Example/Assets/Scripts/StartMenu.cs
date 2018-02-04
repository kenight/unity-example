using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class StartMenu : MonoBehaviour {

	public InputField inputField;
	public LobbyManager lobbyManager;

	public void PlayNow() {

		if (inputField.text.Trim().Length > 0) {
			// Set NetworkPlayer's Name
			PhotonNetwork.playerName = inputField.text;

			// Set CustomProperties
			PhotonNetwork.player.SetSprite(MyPlayerSettings.instance.spriteIndex);

			// Join or create a room
			lobbyManager.JoinRoom();
		}
	}

	public void SelectPlayer(int index) {
		MyPlayerSettings.instance.spriteIndex = index;
	}

}