using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 检查是否玩家超出场景范围等 Bug
public class BugCheck : MonoBehaviour
{
    public float outOfMinY = -10;
    public Transform player;

    void FixedUpdate()
    {
        if (player.position.y < outOfMinY)
        {
            GameManager.instance.GameOver();
            this.enabled = false;
        }
    }
}
