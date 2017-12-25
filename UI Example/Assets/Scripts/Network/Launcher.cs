using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : Photon.PunBehaviour {

	public byte maxPlayersPerRoom = 4;
	public InputField input;
	public GameObject playerButton;
	public GameObject waitButton;
	private string gameVersion = "0.1";

	// 注意这里有个问题，如果从其他场景返回到本场景会自动又加入房间
	// 因为 OnConnectedToMaster 只要检测到连接到服务器，则会执行 PhotonNetwork.JoinRandomRoom() 方法
	// 使用 isConnecting flag 来解决这个问题
	private bool isConnecting = false;

	void Awake() {
		// we don't join the lobby. There is no need to join a lobby to get the list of rooms.
		PhotonNetwork.autoJoinLobby = false;
		// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
		PhotonNetwork.automaticallySyncScene = true;
	}

	// Used by StartMenu.PlayNow()
	// Start the connection process, connect this application instance to Photon Cloud Server
	public void Connect() {
		isConnecting = true;
		// UI
		playerButton.SetActive(false);
		waitButton.SetActive(true);
		input.interactable = false;
		// Connect to master
		if (!PhotonNetwork.connected) {
			PhotonNetwork.ConnectUsingSettings(gameVersion);
		}

	}

	// Callbacks for ConnectUsingSettings()
	public override void OnConnectedToMaster() {
		Debug.Log("Launcher : OnConnectedToMaster() was called by PUN");
		// if already connected, we attempt joining a random room
		if (isConnecting)
			PhotonNetwork.JoinRandomRoom();
	}

	// Callbacks for ConnectUsingSettings()
	public override void OnDisconnectedFromPhoton() {
		// UI
		playerButton.SetActive(true);
		waitButton.SetActive(false);
		input.interactable = true;

		Debug.Log("Launcher : OnDisconnectedFromPhoton() was called by PUN");
	}

	// Callbacks for JoinRandomRoom()
	public override void OnPhotonRandomJoinFailed(object[] codeAndMsg) {
		Debug.Log("Launcher : OnPhotonRandomJoinFailed() was called by PUN. No random room available");
		// create a new room
		PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = maxPlayersPerRoom }, null);
	}

	// Callbacks for JoinRandomRoom()
	public override void OnJoinedRoom() {
		Debug.Log("Launcher: OnJoinedRoom() called by PUN. Now this client is in a room");

		if (PhotonNetwork.room.PlayerCount == 1) {
			if (PhotonNetwork.isMasterClient)
				PhotonNetwork.LoadLevel("Arena");
		}
	}

}