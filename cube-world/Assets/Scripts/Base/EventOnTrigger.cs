using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
// 检测并响应触发器事件
public class EventOnTrigger : EventOnCollisionBase
{
    private Collider2D col;

    void Start()
    {
        // 自动设置为 trigger
        col = GetComponent<Collider2D>();
        if (col.isTrigger == false)
            col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (when == When.Enter)
            Execute(other);

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (when == When.Exit)
            Execute(other);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (when == When.Stay)
            Execute(other);
    }
}
