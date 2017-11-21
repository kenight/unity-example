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
    [HideInInspector]
    public bool pause = false;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    // 获得金币
    public void GainCoins(int amount)
    {
        coins += amount;
        coins = Mathf.Clamp(coins, 0, 999);
    }

    // 消耗 sp
    public void ConsumeSp(float amount)
    {
        sp = Mathf.Clamp(sp - amount, 0, maxSp);
    }

    // 恢复 sp
    public void RecoverSp()
    {
        sp = Mathf.Clamp(sp + 100 * Time.deltaTime * recoverRatio, 0, maxSp);
    }

    public IEnumerator GameOver()
    {
        pause = true;
        yield return new WaitForSeconds(2f);
        GetComponent<GoAndFadeOut>().NextScene();
    }

}
