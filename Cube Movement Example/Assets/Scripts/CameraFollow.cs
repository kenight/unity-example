using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 相机跟随脚本，主要作用 2D 横板过关游戏
// 相机宽度：因为场景长度不确定，所有使用左右两个 Collider2D 来限制范围，同时还起到阻挡玩家移出场景外
// 相机高度：可以根据搭建场景时摆放的参考高度作为最小高度，最大高度比较随意
public class CameraFollow : MonoBehaviour
{
	[Tooltip("跟随目标")]
    public Transform target;
	[Tooltip("X轴跟随偏移量")]
    public float offsetX = 1;
	[Tooltip("Y轴跟随偏移量")]
    public float offsetY = 1;
	[Tooltip("跟随平滑系数")]
    public float soomthSpeed = 2;
	[Tooltip("左碰撞体")]
    public Collider2D rangeLeft;
	[Tooltip("右碰撞体")]
    public Collider2D rangeRight;
	[Tooltip("相机最小Y坐标")]
    public float minY = 0;
	[Tooltip("相机最大Y坐标")]
    public float maxY = 20;

    private Camera thisCamera;
    private float halfWidth; // 获取摄像机视野中宽的一半
    private float minX;
    private float maxX;


    // Use this for initialization
    void Awake()
    {
        thisCamera = GetComponent<Camera>();

        // 一半的宽 = 一半的高 * 宽高比
        halfWidth = thisCamera.orthographicSize * thisCamera.aspect;

        minX = rangeLeft.bounds.max.x;
        maxX = rangeRight.bounds.min.x;
    }

    void LateUpdate()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        // 超过 offsetX 后，相机开始 X 方向上的跟随
        if (Mathf.Abs(x - target.position.x) > offsetX)
            x = Mathf.Lerp(x, target.position.x, soomthSpeed * Time.deltaTime);

        // 超过 offsetY 后，相机开始 Y 方向上的跟随
        if (Mathf.Abs(y - target.position.y) > offsetY)
            y = Mathf.Lerp(y, target.position.y, soomthSpeed * Time.deltaTime);

        // 限制相机最大移动范围
        x = Mathf.Clamp(x, minX + halfWidth, maxX - halfWidth);
        y = Mathf.Clamp(y, minY, maxY);
        transform.position = new Vector3(x, y, z);
    }
}
