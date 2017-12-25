using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 自动匹配大厅，不显示房间列表
public class LobbyManager : Photon.PunBehaviour {

	public byte maxPlayersPerRoom = 4;
	public InputField inputField;
	public GameObject playButton;
	public GameObject waitButton;

	public void JoinRoom() {
		// UI effect
		playButton.SetActive(false);
		waitButton.SetActive(true);
		inputField.interactable = false;

		// Join
		PhotonNetwork.JoinRandomRoom();
	}

	// 成功加入房间的回调	
	public override void OnJoinedRoom() {
		Debug.Log("LobbyManager -> OnJoinedRoom() : 加入一个随机房间");
	}

	// 加入房间失败的回调
	public override void OnPhotonRandomJoinFailed(object[] codeAndMsg) {
		Debug.Log("LobbyManager -> OnPhotonRandomJoinFailed() : 没有随机房间可加入");
		// create a new room
		Debug.Log("LobbyManager -> OnPhotonRandomJoinFailed() : 创建一个新房间");
		PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = maxPlayersPerRoom }, null);
	}

	// 当远程玩家加入房间时的回调
	// 注意是远程玩家连接时，其他已在房间的玩家会调用该方法
	public override void OnPhotonPlayerConnected(PhotonPlayer otherPlayer) {
		Debug.Log("LobbyManager -> OnPhotonPlayerConnected() : " + otherPlayer.NickName + " 连入房间");
		// 满足玩家数量后，MasterClient 玩家调用 loadLevel 加载场景
		// PhotonNetwork.automaticallySyncScene = true 必须设置让其他玩家自动同步场景
		if (PhotonNetwork.room.PlayerCount == 2) {
			if (PhotonNetwork.isMasterClient)
				PhotonNetwork.LoadLevel("Arena");
		}
	}

	// 当远程玩家离开房间时的回调
	// 注意是远程玩家离开时，其他已在房间的玩家会调用该方法
	// When your client calls PhotonNetwork.leaveRoom, PUN will call this method on the remaining clients
	// When a remote client drops connection or gets closed, this callback gets executed
	public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer) {
		Debug.Log("LobbyManager -> OnPhotonPlayerDisconnected() : " + otherPlayer.NickName + " 退出房间");
	}

	// 还有一个问题容易忽略，这里的 OnPhotonPlayerConnected 与 OnPhotonPlayerDisconnected 只会通知到 LobbyManager 挂载的场景，即 Start
	// 跳转到 Arena 场景后，这两个回调并不存在，需要另外定义，因为在 lobby 或 游戏中的处理玩家加入与退出的逻辑并不一定相同
}