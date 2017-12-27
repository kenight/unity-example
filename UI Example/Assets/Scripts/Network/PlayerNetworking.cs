using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNetworking : Photon.PunBehaviour, IPunObservable {

	public PlayerController playerController;
	public GameObject controlUI;
	public Text playerNameText;

	private Transform cannon;
	private Quaternion receivedCannonRot = Quaternion.identity;

	void Awake() {
		cannon = transform.Find("Body/Cannon");
	}

	void Start() {

		playerNameText.text = photonView.owner.NickName;

		if (!photonView.isMine) {
			playerController.enabled = false;
			controlUI.SetActive(false);
		}
	}

	void Update() {
		if (!photonView.isMine) { // 不在修改该 PhotonView 在本地客户端上的值，因为已通过控制器改变，主要目的是把通过本地控制器改变的值，应用到该 PhotonView 的远程示例上，让其他玩家知道
			// 修改该 PhotonView 在远程客户端上值
			cannon.transform.rotation = Quaternion.Lerp(cannon.transform.rotation, receivedCannonRot, Time.deltaTime * 10);
		}
	}

	// 本地数据同步到远程客户端, 注意，针对的是同一个 PhotonView
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			// 发送本地数据
			stream.SendNext(cannon.rotation);
		} else {
			// 远程客户端接收数据
			receivedCannonRot = (Quaternion) stream.ReceiveNext();
		}
	}

}