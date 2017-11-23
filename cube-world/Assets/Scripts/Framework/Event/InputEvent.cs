using UnityEngine;

public class InputEvent : EventBase
{
    // 根据不同的 InputMode 切换以下
    public string buttonName = "Fire1";
    public KeyCode key = KeyCode.Space;
    public MouseTypes mouseTypes = MouseTypes.Left;


    void Start()
    {
        lastEventTime = -frequency;
    }

    void Update()
    {
        switch (inputMode)
        {
            case InputMode.Joystick:
                JoystickMode();
                break;
            case InputMode.Keyboard:
                KeyboardMode();
                break;
            case InputMode.Mouse:
                MouseMode();
                break;
        }
    }

    void JoystickMode()
    {
        switch (eventType)
        {
            case InputEventTypes.Press:
                if (Input.GetButtonDown(buttonName))
                    ExecActionWithAnimation();
                break;
            case InputEventTypes.Release:
                if (Input.GetButtonUp(buttonName))
                    ExecActionWithAnimation();
                break;
            case InputEventTypes.Hold:
                if (Input.GetButton(buttonName))
                    ExecActionWithAnimation();
                break;
        }
    }

    void KeyboardMode()
    {
        switch (eventType)
        {
            case InputEventTypes.Press:
                if (Input.GetKeyDown(key))
                    ExecActionWithAnimation();
                break;
            case InputEventTypes.Release:
                if (Input.GetKeyUp(key))
                    ExecActionWithAnimation();
                break;
            case InputEventTypes.Hold:
                if (Input.GetKey(key))
                    ExecActionWithAnimation();
                break;
        }
    }

    void MouseMode()
    {
        int mouseValue = 0;

        switch (mouseTypes)
        {
            case MouseTypes.Left:
                mouseValue = 0;
                break;
            case MouseTypes.Right:
                mouseValue = 1;
                break;
            case MouseTypes.Middle:
                mouseValue = 2;
                break;
        }

        switch (eventType)
        {
            case InputEventTypes.Press:
                if (Input.GetMouseButtonDown(mouseValue))
                    ExecActionWithAnimation();
                break;
            case InputEventTypes.Release:
                if (Input.GetMouseButtonUp(mouseValue))
                    ExecActionWithAnimation();
                break;
            case InputEventTypes.Hold:
                if (Input.GetMouseButton(mouseValue))
                    ExecActionWithAnimation();
                break;
        }
    }
}
