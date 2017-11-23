using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveWithAxes : MonoBehaviour
{
    // Movement
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public float speed = 5f;
    public MovementType movementType = MovementType.AllDirections;


    // Facing
    public bool changeFacing = false;
    public bool facingLeft = true;


    // Moving Animation
    public bool useAnimation = false;
    public string parameterName = "Speed";


    private Vector2 movement;
    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody2D rbody2D;


    void Awake()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis(horizontalAxis);
        moveVertical = Input.GetAxis(verticalAxis);

        // 处理移动类型
        switch (movementType)
        {
            case MovementType.OnlyHorizontal:
                moveVertical = 0f;
                break;
            case MovementType.OnlyVertical:
                moveHorizontal = 0f;
                break;
        }

        movement = new Vector2(moveHorizontal, moveVertical);
    }

    void FixedUpdate()
    {
        rbody2D.AddForce(movement * speed * 10f);

        // 直接设置 velocity 居然不能连续触发 OnTriggerStay !!
        // rbody2D.velocity = movement * speed; 

        if (useAnimation)
            GetComponent<Animator>().SetFloat(parameterName, movement.sqrMagnitude);

        if (!changeFacing)
            return;

        if (movement.x < 0 && facingLeft)
            FlipRbody();
        else if (movement.x > 0 && !facingLeft)
            FlipRbody();
    }

    // 翻转刚体
    void FlipRbody()
    {
        facingLeft = !facingLeft;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public enum MovementType
    {
        AllDirections,
        OnlyHorizontal,
        OnlyVertical
    }
}
