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
    private float lastHp;
    private List<GameObject> heartArray = new List<GameObject>();

    void Start()
    {
        // 初始化血量
        lastHp = GameplayManager.instance.hp;

        for (int i = 0; i < GameplayManager.instance.hp; i++)
        {
            GameObject h = Instantiate(heart, bloodBar);
            heartArray.Add(h);
        }

        // 初始化金币
        coinText.text = "x " + GameplayManager.instance.coins;
    }

    void Update()
    {
        // update ui
        InitSpBar();
        UpdateHeart();
        UpdateCoins();
    }

    void InitSpBar()
    {
        float x = Mathf.Lerp(spBar.sizeDelta.x, GameplayManager.instance.sp, 0.12f);
        spBar.sizeDelta = new Vector2(x, spBar.sizeDelta.y);
    }

    // 更新血量
    void UpdateHeart()
    {
        if (GameplayManager.instance.hp < lastHp && heartArray.Count > 0)
        {
            GameObject toDestory = heartArray[heartArray.Count - 1];
            Destroy(toDestory);
            heartArray.Remove(toDestory);
            lastHp = GameplayManager.instance.hp;
        }
    }

    void UpdateCoins()
    {
        if (GameplayManager.instance.coins > lastCoinAmout)
        {
            coinAnim.Play();
            coinText.text = "x " + GameplayManager.instance.coins;
            lastCoinAmout = GameplayManager.instance.coins;
        }
    }

}
