using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUi : MonoBehaviour
{

    public GameObject heart;
    public Transform bloodBar;
    public RectTransform spBar;
    public Animation coinAnim;
    public Text coinText;
    private int lastCoinAmout = 0;

    void Start()
    {
        // 初始化血量
        for (int i = 0; i < GameplayManager.instance.hp; i++)
        {
            Instantiate(heart, bloodBar);
        }

        // 初始化金币
        coinText.text = "x " + GameplayManager.instance.coins;
    }

    void Update()
    {
        // update ui
        InitSpBar();

        UpdateCoins();
    }

    void InitSpBar()
    {
        float x = Mathf.Lerp(spBar.sizeDelta.x, GameplayManager.instance.sp, 0.12f);
        spBar.sizeDelta = new Vector2(x, spBar.sizeDelta.y);
    }

    public void UpdateCoins()
    {
        if (GameplayManager.instance.coins > lastCoinAmout)
        {
            coinAnim.Play();
            coinText.text = "x " + GameplayManager.instance.coins;
            lastCoinAmout = GameplayManager.instance.coins;
        }
    }

}
