using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitPlayer : MonoBehaviour {

	public Text playerNameText;
	public SpriteRenderer bodyRenderer;

	public Sprite[] roleList;

	void Start() {
		playerNameText.text = GameManager.instance.playerName;
		bodyRenderer.sprite = roleList[GameManager.instance.playerIndex];
	}

}