using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonEventHelper : MonoBehaviour {

	public void ScneeLoad(string sceneName) {
		if (sceneName.Length > 0)
			SceneManager.LoadScene(sceneName);
	}

	public void QuitGame() {
		Application.Quit();
	}

}