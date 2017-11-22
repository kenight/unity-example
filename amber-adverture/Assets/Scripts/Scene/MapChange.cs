using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChange : MonoBehaviour
{
    public string mapName;
    public string unload = "NULL";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        SceneManager.LoadScene(mapName, LoadSceneMode.Additive);

        // 卸载场景,当前游戏物体所在的场景
        // SceneManager.UnloadSceneAsync(gameObject.scene);

        // 卸载场景,指定场景
        if (!string.IsNullOrEmpty(unload) && unload != "NULL")
            SceneManager.UnloadSceneAsync(unload);

        gameObject.SetActive(false);
    }

}
