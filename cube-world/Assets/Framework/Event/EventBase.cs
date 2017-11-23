using UnityEngine;

public class EventBase : ActionCapacity
{
    public InputMode inputMode = InputMode.Joystick;
    public InputEventTypes eventType = InputEventTypes.Press;


    // 事件动画设置(只支持参数为Bool、Trigger两种，其它的请写脚本完成)
    public bool useAnimation = false;
    public AnimatorParamTypes parameterTypes = AnimatorParamTypes.Trigger;
    public string parameterName;


    // 事件间隔时间设置
    public bool hasInterval = false;
    public float frequency = 0.5f;
    protected float lastEventTime;

    // 判断是否有执行间隔，并执行 ActionWithAnimation
    protected void ExecActionWithAnimation()
    {
        if (hasInterval)
        {
            if (Time.time >= lastEventTime + frequency)
            {
                ActionWithAnimation();
                lastEventTime = Time.time;
            }
        }
        else
            ActionWithAnimation();
    }

    // 执行 Action 与动画
    void ActionWithAnimation()
    {
        // 是否播放动画
        if (useAnimation)
        {
            // 如果是 Bool 类型
            if (parameterTypes == AnimatorParamTypes.Bool)
                GetComponent<Animator>().SetBool(parameterName, true);
            else
                GetComponent<Animator>().SetTrigger(parameterName);
        }

        // 执行 actions
        ExecuteActions(null);
    }

    public enum InputMode
    {
        Joystick,
        Keyboard,
        Mouse
    }

    public enum InputEventTypes
    {
        Press,          // 按下
        Release,        // 释放
        Hold            // 按住
    }

    public enum MouseTypes
    {
        Left,
        Right,
        Middle
    }

    public enum AnimatorParamTypes
    {
        Bool,
        Trigger
    }
}
