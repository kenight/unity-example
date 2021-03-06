﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Attack : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    public float shotInterval = 0.1f;
    private float timer; // 计时器
    private Animator animator;
    private AnimatorStateInfo stateInfo;
    private Movement movementComponent;
    public float spCost_attack1 = 50f;
    public float spCost_attack3 = 150f;
    public float spCost_shot = 80f;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        movementComponent = GetComponent<Movement>();
        timer = shotInterval;
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
        // 按下 X 同时 sp 足够
        if (Input.GetKeyDown(KeyCode.X) && GameplayManager.instance.sp >= spCost_attack1)
        {
            int combo = animator.GetInteger("AttackCombo") + 1;
            // 如果不满足 attack3 的 sp 量，则只能使用前两招
            if (GameplayManager.instance.sp < spCost_attack3)
                combo = Mathf.Clamp(combo, 0, 2);
            animator.SetInteger("AttackCombo", combo);
        }
    }

    void GunShot()
    {
        if (Input.GetKeyDown(KeyCode.C) && GameplayManager.instance.sp > 0)
            animator.SetBool("Shot", true);

        if (Input.GetKeyUp(KeyCode.C))
            animator.SetBool("Shot", false);

        // 持续消耗 sp
        if (Input.GetKey(KeyCode.C))
        {
            if (GameplayManager.instance.sp == 0)
                animator.SetBool("Shot", false);
            else
                GameplayManager.instance.ConsumeSp(spCost_shot * Time.deltaTime);
        }

        if (animator.GetBool("Shot"))
            Shot();

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

    // Attack_3 的sp 消耗值, 用于 AnimEventController SendMessage 调用
    void Attacke3Sp()
    {
        GameplayManager.instance.ConsumeSp(spCost_attack3);
    }

    // Attack_1 的sp 消耗值, 用于 AnimEventController SendMessage 调用
    void Attacke1Sp()
    {
        GameplayManager.instance.ConsumeSp(spCost_attack1);
    }

    void Shot()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            Instantiate(bullet, shotPoint.position, Quaternion.identity);
            timer = shotInterval;
        }
    }

    public void TakeDamage(int damage)
    {
        // 排除掉从 Damage Stat 进入 Damage Stat (Any Stat 包括 Damage Stat 自身)
        if (stateInfo.IsName("Base Layer.Damage"))
            return;

        GameplayManager.instance.hp -= damage;

        animator.SetTrigger("TakeDamage");

        if (GameplayManager.instance.hp <= 0)
        {
            animator.SetTrigger("Dead");
            gameObject.tag = "Finish"; // 改 tag , 使碰撞检测无用
            StartCoroutine(GameplayManager.instance.GameOver());
        }
    }

}
