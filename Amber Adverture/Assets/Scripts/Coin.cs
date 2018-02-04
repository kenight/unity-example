using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int amount = 1;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        GameplayManager.instance.GainCoins(amount);

        animator.SetTrigger("GainCoin");

        // 销毁掉该脚本,不再进行碰撞检查，物体的销毁应该再动画播放完毕后(animation event)
        Destroy(this);
    }
}
