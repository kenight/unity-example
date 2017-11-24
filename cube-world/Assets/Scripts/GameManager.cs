using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerControl playerControl;
    public GameObject gameOverPanel;

    void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        playerControl.animator.SetTrigger("Dead");
        playerControl.StopAction();
        playerControl.enabled = false;
        gameOverPanel.SetActive(true);
    }
}
