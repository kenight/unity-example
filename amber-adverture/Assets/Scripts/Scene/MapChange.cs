using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChange : MonoBehaviour
{
    public string mapName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;
        SceneManager.LoadScene(mapName, LoadSceneMode.Additive);
        // unload 当前游戏物体所在的场景
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }

}
