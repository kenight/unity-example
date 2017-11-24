using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// EventOnCollision 与 EventOnTrigger 的基类
public abstract class EventOnCollisionBase : MonoBehaviour
{
    public When when = When.Enter;
    public bool enableCompare = true;
    public string compareFor = "Player";
    
    [Tooltip("方法是否只执行一次")]
    public bool onlyOnce = false;
    private bool happened = false;
    public UnityEvent unityEvent;
    [Tooltip("勾选后只执行自定义方法")]
    public bool useCustomize = false;
    [Tooltip("自定义的脚本")]
    public EventOnCollisionFunc customFunc;

    protected void Execute(Collider2D other)
    {
        if (onlyOnce && happened)
            return;

        if (!enableCompare || other.CompareTag(compareFor))
        {
            if (useCustomize)
                customFunc.Invoke(other);
            else
                unityEvent.Invoke();
        }

        happened = true;
    }

    public enum When
    {
        Enter,
        Exit,
        Stay
    }
}
