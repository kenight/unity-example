using UnityEngine;

public abstract class CollisionBase : ActionCapacity
{
    // Tags
    public bool enableCompare = false;
    public string compareFor = "Player";


    // 检测频率 for Stay
    public float frequency = 1f;
    protected float lastDetectTime;

}
