using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworking : Photon.MonoBehaviour {

	private Transform cannon;
	private Quaternion receivedCannonRot = Quaternion.identity; // 先赋值，不然有可能 Lerp 出错

	void Awake() {
		cannon = transform.Find("Body/Cannon");
	}

	void Update() {
		if (!photonView.isMine) {
			// 通过 OnPhotonSerializeView 同步数据后，改变 cannon 的 rotation 并作平滑处理
			cannon.transform.rotation = Quaternion.Lerp(cannon.transform.rotation, receivedCannonRot, Time.deltaTime * 10);
		}
	}

	// 同步该 PhotonView 的本地与网络数据
	// 注意一个概念容易混淆
	// 假设该脚本属于 PhontonView[id is 1], 这里同步只是同步 PhontonView[1] 的在本地操作的数据到网络
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			// 将本地对 Player 的改变数据发送到网络上
			stream.SendNext(cannon.rotation);
		} else {
			// 网络上的该 Player 接受数据，并做相应改变
			receivedCannonRot = (Quaternion) stream.ReceiveNext();
		}
	}

}