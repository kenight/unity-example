using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 定义一些公用方法供 animation event 进行调用
public class AnimEventController : MonoBehaviour
{
    // 通过 SendMessage 来调用其他脚本方法
    void CallMethod(string methodName)
    {
        // SendMessage：Calls the method named methodName on every MonoBehaviour in this game object.
        // 调用 Root GameObject's SendMessage 方法，即呼叫的是 Root GameObject 上的脚本中的方法
        transform.root.SendMessage(methodName, SendMessageOptions.DontRequireReceiver);
    }

    // Animation Event 只支持一个字符串参数，如果想传递多个参数，如下定义
    void CallMethodWithAnimationEvent(AnimationEvent e)
    {
        // 这样 AnimationEvent 总共可以支持4个参数类型
        transform.root.SendMessage(e.stringParameter, SendMessageOptions.DontRequireReceiver);
    }

    void DestoryObject()
    {
        Destroy(gameObject);
    }
}
