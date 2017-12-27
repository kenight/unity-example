using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArenaGameManager : Photon.PunBehaviour {

	// 通过 Photon Instantiate 的 prefab 必须放在 Resources 文件夹中
	public GameObject playerPrefab;
	public Sprite[] playerSprites;

	void Start() {
		// Instantiate Player
		if (playerPrefab) {
			// 注意第一个参数是 playerPrefab 的 name
			PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-3.5f, 0.8f, 0), Quaternion.identity, 0);
		}
	}

	public void LeaveRoom() {
		PhotonNetwork.LeaveRoom();
	}

	// 退出房间的回调
	public override void OnLeftRoom() {
		SceneManager.LoadScene(0);
	}

	public override void OnPhotonPlayerConnected(PhotonPlayer otherPlayer) {
		Debug.Log("NetworkingManager -> OnPhotonPlayerConnected() : " + otherPlayer.NickName + " 连入房间");
	}

	public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer) {
		Debug.Log("NetworkingManager -> OnPhotonPlayerDisconnected() : " + otherPlayer.NickName + " 退出房间");
	}
}