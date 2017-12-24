using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : Photon.PunBehaviour {

	public byte maxPlayersPerRoom = 4;
	private string gameVersion = "0.1";

	void Awake() {
		// we don't join the lobby. There is no need to join a lobby to get the list of rooms.
		PhotonNetwork.autoJoinLobby = false;
		// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
		PhotonNetwork.automaticallySyncScene = true;
	}

	void Start() {
		Connect();
	}

	// Start the connection process
	// if already connected, we attempt joining a random room
	// if not yet connected, Connect this application instance to Photon Cloud Server
	void Connect() {
		if (PhotonNetwork.connected)
			PhotonNetwork.JoinRandomRoom();
		else
			PhotonNetwork.ConnectUsingSettings(gameVersion);
	}

	// Callbacks for ConnectUsingSettings()
	public override void OnConnectedToMaster() {
		Debug.Log("Launcher : OnConnectedToMaster() was called by PUN");
	}

	// Callbacks for ConnectUsingSettings()
	public override void OnDisconnectedFromPhoton() {
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
	}

}