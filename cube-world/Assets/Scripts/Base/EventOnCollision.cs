using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 检测并响应碰撞事件
[RequireComponent(typeof(Collider2D))]
public class EventOnCollision : EventOnCollisionBase
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (when == When.Enter)
            Execute(other.collider);

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (when == When.Exit)
            Execute(other.collider);
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (when == When.Stay)
            Execute(other.collider);
    }
}
