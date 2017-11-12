using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    public float hp = 5f;
    public float sp = 500f;
    public int coins = 0;


    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    public void GainCoins(int amount)
    {
        coins += amount;
        coins = Mathf.Clamp(coins, 0, 999);
    }
}
