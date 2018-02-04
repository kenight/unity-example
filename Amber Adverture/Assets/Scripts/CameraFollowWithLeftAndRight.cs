using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 通过 RangeLeft 与 RangeRight 来限制左右边界
// RangeLeft 与 RangeRight 使用 Collider2D, 即限制边界又限制人物掉出场景外
// 只限制了 X 轴，Y 轴如果要限制，不使用该方法，感觉采用 2D platformer 项目的方法更好
public class CameraFollowWithLeftAndRight : MonoBehaviour
{
    public Transform followAt;
    private Collider2D rangeLeft;
    private Collider2D rangeRight;
    private Camera thisCamera;
    private Vector2 maxLeft; // rangeLeft collider bounds 左上角的点
    private Vector2 maxRight; // rangeRight collider bounds 右下角的点
    private float visibleWidth;
    private float visibleHeight;

    // Use this for initialization
    void Awake()
    {
        rangeLeft = GameObject.FindWithTag("RangeLeft").GetComponent<Collider2D>();
        rangeRight = GameObject.FindWithTag("RangeRight").GetComponent<Collider2D>();

        thisCamera = GetComponent<Camera>();
    }

    void Start()
    {
        maxLeft = rangeLeft.bounds.max;

        if (rangeRight != null)
            maxRight = rangeRight.bounds.min;

        GetVisible();
    }

    void Update()
    {
        float x;
        if (rangeRight != null)
            // 如果存在，则限制左与右
            x = Mathf.Clamp(followAt.position.x, maxLeft.x + visibleWidth, maxRight.x - visibleWidth);
        else
            // 如果不存在，则只限制左边界
            x = followAt.position.x > maxLeft.x + visibleWidth ? followAt.position.x : maxLeft.x + visibleWidth;

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    // 获取可视区域高宽的一半
    void GetVisible()
    {
        float distance = Mathf.Abs(transform.position.z);
        visibleHeight = distance * Mathf.Tan(thisCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        visibleWidth = visibleHeight * thisCamera.aspect;
    }
}
