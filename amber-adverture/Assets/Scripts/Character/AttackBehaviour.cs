using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // 用于判定连招触发时机，留下了作为示例，并未使用方法
    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     if (!enableThreshold)
    //         return;

    //     // 动画 normalizedTime 小于阈值，则 AttackCombo 的值将锁定到 attackComboValue , 换句话只有在阈值之后操作才进入下段攻击动画
    //     if (stateInfo.normalizedTime <= threshold)
    //     {
    //         animator.SetInteger("AttackCombo", attackComboValue);
    //     }
    // }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // 攻击动画完成后，立刻重置 AttackCombo
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("AttackCombo", 0);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
