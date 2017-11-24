using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 配合 EventOnCollisionBase 执行自定方法
// 主要意义在于传递出碰撞的另一方
public class EventOnCollisionFunc : MonoBehaviour
{
    // 继承类可重载该方法实现具体逻辑
    public virtual void Invoke(Collider2D other) { }
}
