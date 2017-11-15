using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{

    public float waklSpeed = 15f;
    public float runSpeed = 25f;
    public float jumpHeight = 12f; // with Gravity scale 3
    private Rigidbody2D character;
    private Animator animator;
    private float horizontalAxis;
    private bool facingLeft = true;
    private Transform detectPoint;
    private bool grounded = true;
    [HideInInspector]
    public bool locked = false;

    void Awake()
    {
        character = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        detectPoint = transform.Find("GroundDetect");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameplayManager.instance.pause)
        {
            StopMoving();
            return;
        }

        Move();

        GroundedDetect();

        Jump();

        AnimStateMachine();
    }

    void Move()
    {
        horizontalAxis = Input.GetAxis("Horizontal");

        // 朝向
        if (horizontalAxis < 0 && facingLeft)
            FlipFace();
        else if (horizontalAxis > 0 && !facingLeft)
            FlipFace();

        // 锁定之后，可以转向，不能移动
        if (locked)
        {
            // 如果人物在地上，立即禁止水平移动
            if (grounded)
                character.velocity = new Vector2(0, character.velocity.y);
            return;
        }

        float absSpeed = Mathf.Abs(horizontalAxis);
        float speed = waklSpeed;
        float moveThreshold = 0;

        // Run
        if (absSpeed > 0 && Input.GetKey(KeyCode.V))
        {
            speed = runSpeed;
            moveThreshold = 1f;
        }
        // Walk
        else if (absSpeed > 0)
        {
            moveThreshold = 0.5f;
        }

        character.velocity = new Vector2(speed * 10 * horizontalAxis * Time.deltaTime, character.velocity.y);
        animator.SetFloat("Move", moveThreshold);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!grounded || locked)
                return;

            character.velocity = new Vector2(character.velocity.x, jumpHeight);
            animator.SetTrigger("Jump");
        }
    }

    void FlipFace()
    {
        if (facingLeft)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
        facingLeft = !facingLeft;
    }

    // 利用射线检测是否接触地面
    void GroundedDetect()
    {
        grounded = Physics2D.Linecast(transform.position, detectPoint.position, 1 << LayerMask.NameToLayer("Ground"));
    }

    // 实时更新动画状态 Parameters
    void AnimStateMachine()
    {
        animator.SetBool("Grounded", grounded);
        animator.SetFloat("SpeedY", character.velocity.y);
    }

    void StopMoving()
    {
        character.velocity = new Vector2(0, 0);
        animator.SetFloat("Move", 0);
    }

}
