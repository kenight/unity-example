using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectToMaster : Photon.PunBehaviour {

	public InputField inputField;
	public GameObject connectingButton;
	public GameObject playButton;

	private string gameVersion = "0.1";

	void Awake() {
		// we don't join the lobby. There is no need to join a lobby to get the list of rooms.
		PhotonNetwork.autoJoinLobby = false;
		// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
		PhotonNetwork.automaticallySyncScene = true;
	}

	// 加载该脚本时，直接连接服务器
	void Start() {
		// 未连接到任何 Photon 服务器时,才进行连接
		if (!PhotonNetwork.connected) {
			Debug.Log("ConnectToMaster -> Start() : 开始连接服务器");
			PhotonNetwork.ConnectUsingSettings(gameVersion);
		}
	}

	// 连接成功时的回调方法 ConnectUsingSettings()
	public override void OnConnectedToMaster() {
		Debug.Log("ConnectToMaster -> OnConnectedToMaster() : 连接成功");
		connectingButton.SetActive(false);
		playButton.SetActive(true);
		inputField.interactable = true;
	}

	// 连接失败或断开时的回调方法
	public override void OnDisconnectedFromPhoton() {
		Debug.Log("ConnectToMaster -> OnDisconnectedFromPhoton() : 连接失败");
	}
}