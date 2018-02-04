using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 接收并响应键盘事件
public class EventKeyboard : MonoBehaviour
{
    public KeyCode key = KeyCode.Space;
    public InputTypes type = InputTypes.KeyDown;
    public UnityEvent unityEvent;

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case InputTypes.KeyDown:
                if (Input.GetKeyDown(key))
                    unityEvent.Invoke();
                break;
            case InputTypes.KeyUp:
                if (Input.GetKeyUp(key))
                    unityEvent.Invoke();
                break;
            case InputTypes.KeyHold:
                if (Input.GetKey(key))
                    unityEvent.Invoke();
                break;
        }
    }

    public enum InputTypes
    {
        KeyDown,
        KeyUp,
        KeyHold
    }
}
