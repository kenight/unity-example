using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    [Range(0, 0.1f)]
    public float fadeSpeed = 0.05f;
    public Image block;

    void Start()
    {
        FadeIn();
    }

    void Update()
    {
        // 每帧改变透明度
        Color color = block.color;
        color.a += fadeSpeed;
        color.a = Mathf.Clamp01(color.a);
        block.color = color;

        // 淡入后隐藏物体(淡出不管，一般淡出后马上跳转场景)
        if (color.a == 0)
        {
            this.gameObject.SetActive(false);
        }

    }

    void FadeIn()
    {
        Color color = block.color;
        color.a = 1;
        block.color = color;
        // 淡入是透明度从 1 -> 0 的过程，所有速度取负
        fadeSpeed = -Mathf.Abs(fadeSpeed);
    }

    public void FadeOut()
    {
        // 重新激活物体
        this.gameObject.SetActive(true);

        Color color = block.color;
        color.a = 0;
        block.color = color;
        fadeSpeed = Mathf.Abs(fadeSpeed);
    }

}
