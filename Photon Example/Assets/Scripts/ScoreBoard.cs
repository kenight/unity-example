using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : Photon.PunBehaviour {

	public GameObject[] playerKds;

	void Update() {
		if (!PhotonNetwork.inRoom)
			return;

		PhotonPlayer[] players = PhotonNetwork.playerList;

		for (int i = 0; i < players.Length; i++) {
			playerKds[i].SetActive(true);
			playerKds[i].GetComponent<Text>().text = players[i].NickName + " - kill:" + players[i].GetKill() + " dead:" + players[i].GetDead();
		}
	}

}