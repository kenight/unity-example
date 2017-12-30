using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Photon.PunBehaviour, IPunObservable {

	public PlayerController playerController;
	public PlayerHealth playerHealth;
	public Sprite[] playerSprites;
	public SpriteRenderer playerSprite;
	public GameObject controlUI;
	public Text playerNameText;

	private Transform cannon;
	private Quaternion receivedCannonRot = Quaternion.identity;

	void Awake() {
		cannon = transform.Find("Body/Cannon");
	}

	void Start() {
		playerNameText.text = photonView.owner.NickName;

		// 从 Custom Properties 中读取
		ExitGames.Client.Photon.Hashtable playerProps = photonView.owner.CustomProperties;
		if (playerProps.ContainsKey("spriteIndex")) {
			playerSprite.sprite = playerSprites[(int) playerProps["spriteIndex"]];
		}

		if (!photonView.isMine) {
			playerController.controlled = false;
			controlUI.SetActive(false);
		}
	}

	void Update() {
		// 同步本地的值，所有只需要修改远程客户端 !isMine
		if (!photonView.isMine) {
			// 同步 cannon 旋转
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