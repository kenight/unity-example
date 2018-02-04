using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitLoadScene : MonoBehaviour
{
    public string mapName;

    void Awake()
    {
        SceneManager.LoadScene(mapName, LoadSceneMode.Additive);
    }
}
