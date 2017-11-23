using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class ActionCapacity : MonoBehaviour
{
    // Actions
    public List<BaseAction> gameplayActions = new List<BaseAction>();
    public bool useUnityEvent = false;
    public UnityEvent unityEvents;
    public bool onlyOnce = false;
    private bool happened = false;


    // 执行 Actions
    public void ExecuteActions(GameObject other)
    {
        // 如果只能触发一次，且已触发过，则直接返回
        if (onlyOnce && happened)
            return;

        foreach (BaseAction action in gameplayActions)
        {
            action.ExecuteAction(other);
        }

        if (useUnityEvent)
            // 执行 unity 内置事件
            unityEvents.Invoke();

        // 所有 action 标识为已触发
        happened = true;
    }
}
