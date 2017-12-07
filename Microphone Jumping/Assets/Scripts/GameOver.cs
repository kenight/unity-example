using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Transform player;

	void FixedUpdate() {
		if (player.transform.position.y < -6)
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}