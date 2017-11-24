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
            UnityEventExc(other);

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (when == When.Exit)
            UnityEventExc(other);
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (when == When.Stay)
            UnityEventExc(other);
    }

    void UnityEventExc(Collision2D other)
    {
        if (!enableCompare || other.collider.CompareTag(compareFor))
            unityEvent.Invoke();
    }
}
