using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUi : MonoBehaviour
{
    public Dialog dialog;
    private Animation anim;

    void Awake()
    {
        this.enabled = false;
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && GameplayManager.instance.pause == true)
        {
			// 下一句
            dialog.Next();
            // GameplayManager.instance.HideDialog();
        }

    }

    public void Show()
    {
        // 正播动画
        anim["DialogAnimation"].normalizedTime = 0;
        anim["DialogAnimation"].speed = 1;
        anim.Play();
    }

    public void Hide()
    {
        // 倒播动画
        anim["DialogAnimation"].normalizedTime = 1;
        anim["DialogAnimation"].speed = -1;
        anim.Play();
    }

}
