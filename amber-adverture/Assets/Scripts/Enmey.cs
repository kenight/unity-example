using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enmey : MonoBehaviour
{
    public float speed = 10f;
    public float stopDistance = 1.2f;
    public Vector2 searchRange = new Vector2(6, 2);
    private Animator anim;
    private bool isFollow = false;
    private Transform player;
    private Rigidbody2D enmey;

    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        enmey = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        StartCoroutine(SearchPlayer());

        anim.SetBool("Move", isFollow);

        float offset = player.position.x - transform.position.x;

        if (Mathf.Abs(offset) <= stopDistance)
            isFollow = false;

        if (isFollow)
            FollowPlayer(offset);
    }

    void FollowPlayer(float offset)
    {
        //  Mathf.Sign 返回符号，速度由 speed 确定，不由两者距离确定
        float moveSpeed = speed * 0.1f * Mathf.Sign(offset);
        enmey.velocity = new Vector2(moveSpeed, 0);
    }

    // 辅助线
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, searchRange);
    }

    // 搜索 Player
    IEnumerator SearchPlayer()
    {
        Collider2D col = Physics2D.OverlapBox(transform.position, searchRange, 0, 1 << LayerMask.NameToLayer("Player"));

        yield return new WaitForSeconds(0.5f); // 延迟一段时间开始 follow

        if (col != null)
            isFollow = true;
        else
            isFollow = false;
    }

}
