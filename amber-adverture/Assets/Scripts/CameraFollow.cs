using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public GameObject range;

    private Collider rangeCollider;
    private Camera thisCamera;
    private Vector3 minRange;
    private Vector3 maxRange;
    private float visibleWidth;
    private float visibleHeight;


    void Awake()
    {
        rangeCollider = range.GetComponent<Collider>();
        thisCamera = GetComponent<Camera>();
    }

    void Start()
    {
        minRange = rangeCollider.bounds.min;
        maxRange = rangeCollider.bounds.max;

        GetVisible();
    }

    void Update()
    {
        // 限制摄像机可移动范围
        float x = Mathf.Clamp(target.position.x, minRange.x + visibleWidth, maxRange.x - visibleWidth);
        float y = Mathf.Clamp(target.position.y, minRange.y + visibleHeight, maxRange.y - visibleHeight);

        transform.position = new Vector3(x, y, transform.position.z);
    }

    void GetVisible()
    {
        // 可视区域宽度与高度的一半
        float distance = Mathf.Abs(transform.position.z);
        visibleHeight = distance * Mathf.Tan(thisCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        visibleWidth = visibleHeight * thisCamera.aspect;
    }
}
