using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// 使用 NetworkBehaviour 替代 MonoBehaviour
// 使用 isLocalPlayer 判断是否本地客户端的脚本
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : NetworkBehaviour {
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
    // 角色的 SpriteRenderer
    private SpriteRenderer sprite;
    // 是否接触地面
    private bool grounded = true;

    // Use this for initialization
    void Awake() {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundDetect = transform.Find("GroundDetect");
        sprite = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }

    // OnStartLocalPlayer 方法只会初始化本地客户端内容
    public override void OnStartLocalPlayer() {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 255);
    }

    void Update() {
        // 如果不是本地客户端,则不能控制
        if (!isLocalPlayer)
            return;

        hAxis = Input.GetAxis("Horizontal");

        grounded = Physics2D.Linecast(transform.position, groundDetect.position, 1 << LayerMask.NameToLayer("Ground"));

        if (grounded && Input.GetKeyDown(KeyCode.Space))
            jumped = true;
    }

    void FixedUpdate() {
        // Run
        player.velocity = new Vector2(speed * hAxis, player.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(hAxis));

        Jump();

        // Flip
        if (hAxis < 0 && faceRight)
            Flip();
        else if (hAxis > 0 && !faceRight)
            Flip();
    }

    void Jump() {
        if (jumped) {
            player.AddForce(Vector2.up * jumpForce);
            jumped = false;
        }
    }

    void Flip() {
        faceRight = !faceRight;
        Vector2 scale = transform.lossyScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}