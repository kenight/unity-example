using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionCollider : CollisionBase
{
    // 碰撞检测时机
    public CollisionTime collisionTime = CollisionTime.Enter;


    void Start()
    {
        lastDetectTime = -frequency;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (collisionTime == CollisionTime.Enter)
        {
            if (!enableCompare || other.collider.CompareTag(compareFor))
                ExecuteActions(other.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (collisionTime == CollisionTime.Stay && Time.time >= lastDetectTime + frequency)
        {
            if (!enableCompare || other.collider.CompareTag(compareFor))
            {
                ExecuteActions(other.gameObject);
                lastDetectTime = Time.time;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (collisionTime == CollisionTime.Exit)
        {
            if (!enableCompare || other.collider.CompareTag(compareFor))
                ExecuteActions(other.gameObject);
        }
    }

    public enum CollisionTime
    {
        Enter,
        Exit,
        Stay
    }
}
