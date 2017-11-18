using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enmey : MonoBehaviour
{
    public float speed = 10f;
    public float attackDistance = 1.2f;
    public Vector2 searchRange = new Vector2(6, 2);
    private Animator anim;
    private bool isFollow = false;
    private bool attack = false;
    private Transform player;
    private Rigidbody2D enmey;
    private bool facingLeft = true;

    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        enmey = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        StartCoroutine(SearchPlayer());

        float offset = player.position.x - transform.position.x;

        anim.SetBool("Move", isFollow);

        if (isFollow)
        {
            FollowPlayer(offset);
            // 判断是否进入攻击距离
            attack = Mathf.Abs(offset) <= attackDistance;
            if (attack)
                enmey.velocity = new Vector2(0, 0);
            anim.SetBool("Attack", attack);
        }

        if (enmey.velocity.x < 0 && !facingLeft)
            Flip();
        else if (enmey.velocity.x > 0 && facingLeft)
            Flip();

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

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 scale = transform.localScale;
        scale.x = scale.x * -1;
        transform.localScale = scale;
    }

}
