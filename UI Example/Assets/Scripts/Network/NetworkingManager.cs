using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkingManager : Photon.PunBehaviour {

	// 通过 Photon Instantiate 的 prefab 必须放在 Resources 文件夹中
	public GameObject playerPrefab;

	void Start() {
		// Instantiate Player
		if (playerPrefab) {
			// 注意第一个参数是 playerPrefab 的 name
			GameObject myPlayer = PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-3.5f, 0.8f, 0), Quaternion.identity, 0);
		}
	}

	public void LeaveRoom() {
		PhotonNetwork.LeaveRoom();
	}

	// 退出房间的回调
	public override void OnLeftRoom() {
		SceneManager.LoadScene(0);
	}

	// 下面两个回调在 Arena 场景中响应回调

	public override void OnPhotonPlayerConnected(PhotonPlayer otherPlayer) {
		Debug.Log("NetworkingManager -> OnPhotonPlayerConnected() : " + otherPlayer.NickName + " 连入房间");
	}

	public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer) {
		Debug.Log("NetworkingManager -> OnPhotonPlayerDisconnected() : " + otherPlayer.NickName + " 退出房间");
	}
}