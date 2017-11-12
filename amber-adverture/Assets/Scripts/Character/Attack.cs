using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Attack : MonoBehaviour
{

    private Animator animator;
    private AnimatorStateInfo stateInfo;
    private Movement movementComponent;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        movementComponent = GetComponent<Movement>();
    }

    void Update()
    {
        Fighting();

        GunShot();

        LockedState();
    }

    // 近战
    void Fighting()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetInteger("AttackCombo", animator.GetInteger("AttackCombo") + 1);
        }
    }

    void GunShot()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("Shot", true);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("Shot", false);
        }
    }

    // 对 Tag 标记为 LockedState 的状态进行锁定
    void LockedState()
    {
        // 获取当前 Animator 的状态机
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsTag("LockedState"))
        {
            // 限制角色移动的标记
            movementComponent.locked = true;
        }

    }

}
