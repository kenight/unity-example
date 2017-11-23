using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CollisionTrigger : CollisionBase
{
    // 触发检测时机
    public TriggerTime triggerTime = TriggerTime.Enter;


    void Start()
    {
        lastDetectTime = -frequency;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggerTime == TriggerTime.Enter)
        {
            // 如果 enableCompare == false 则无需匹配 tag
            if (!enableCompare || other.CompareTag(compareFor))
                ExecuteActions(other.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (triggerTime == TriggerTime.Stay && Time.time >= lastDetectTime + frequency)
        {
            if (!enableCompare || other.CompareTag(compareFor))
            {
                ExecuteActions(other.gameObject);
                lastDetectTime = Time.time;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (triggerTime == TriggerTime.Exit)
        {
            if (!enableCompare || other.CompareTag(compareFor))
                ExecuteActions(other.gameObject);
        }
    }

    public enum TriggerTime
    {
        Enter,
        Exit,
        Stay
    }
}
