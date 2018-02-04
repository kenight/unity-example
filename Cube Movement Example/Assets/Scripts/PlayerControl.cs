using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    [Tooltip("速度")]
    public float speed = 8;
    [Tooltip("弹跳力")]
    public float jumpForce = 350;

    private bool faceRight = true;
    private Rigidbody2D player;
    [HideInInspector]
    public Animator animator;
    // Horizontal
    private float hAxis;
    // 是否起跳
    private bool jumped = false;
    // 地面检查
    private Transform groundDetect;
    // 是否接触地面
    private bool grounded = true;

    // Use this for initialization
    void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundDetect = transform.Find("GroundDetect");
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxis("Horizontal");

        grounded = Physics2D.Linecast(transform.position, groundDetect.position, 1 << LayerMask.NameToLayer("Ground"));

        if (grounded && Input.GetKeyDown(KeyCode.Space))
            jumped = true;

        UpdateAnimatorState();
    }

    void FixedUpdate()
    {
        // Run
        player.velocity = new Vector2(speed * hAxis, player.velocity.y);

        Jump();

        // Flip
        if (hAxis < 0 && faceRight)
            Flip();
        else if (hAxis > 0 && !faceRight)
            Flip();
    }

    void Jump()
    {
        if (jumped)
        {
            player.AddForce(Vector2.up * jumpForce);
            animator.SetTrigger("Jump");
            jumped = false;
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector2 scale = transform.lossyScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // 持续更新的状态
    void UpdateAnimatorState()
    {
        animator.SetFloat("Speed", Mathf.Abs(hAxis));
        animator.SetFloat("SpeedY", player.velocity.y);
        animator.SetBool("Grouned", grounded);
    }

    // 停止所有行动
    public void StopAction()
    {
        player.velocity = new Vector2(0, 0);
        animator.SetFloat("Speed", 0);
        animator.SetFloat("SpeedY", 0);
    }

}
