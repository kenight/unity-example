using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    public float hp = 5f;
    public float sp = 500f;
    public float maxSp = 500f;
    public float recoverRatio = 1f;
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

    public void ConsumeSp(float amount)
    {
        sp = Mathf.Clamp(sp - amount, 0, maxSp);
    }

    public void RecoverSp()
    {
        sp = Mathf.Clamp(sp + 100 * Time.deltaTime * recoverRatio, 0, maxSp);
    }
}
