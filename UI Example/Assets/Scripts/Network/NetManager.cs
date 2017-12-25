using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetManager : Photon.PunBehaviour {

	public void LeaveRoom() {
		PhotonNetwork.LeaveRoom();
	}

	// Callback for LeaveRoom()
	public override void OnLeftRoom() {
		SceneManager.LoadScene(0);
	}

	// Called when a remote player entered the room
	public override void OnPhotonPlayerConnected(PhotonPlayer otherPlayer) {
		Debug.Log("NetManager : " + otherPlayer.NickName + " connected");
		// LoadArena();
	}

	// Called when a remote player left the room
	public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer) {
		Debug.Log("NetManager : " + otherPlayer.NickName + " disconnected");
		// LoadArena();
	}

	void LoadArena() {
		// LoadLevel should only be called by master
		if (PhotonNetwork.isMasterClient)
			PhotonNetwork.LoadLevel("Arena");
	}
}