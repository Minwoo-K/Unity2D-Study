using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigid2D : MonoBehaviour
{
    // SereializeFields
    [SerializeField]
    private LayerMask groundLayers;

    [SerializeField]
    private float walkSpeed = 8f;
    [SerializeField]
    private float runSpeed = 13f;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float lowGravityScale = 2f;
    [SerializeField]
    private float highGravityScale = 3.5f;

    // Private Variables
    private float moveSpeed;
    private Rigidbody2D rigid2D;
    private new Collider2D collider;
    private Vector2 collisionSize;
    //private Vector2 headPosition;
    private Vector2 feetPosition;

    // Properties
    public bool IsOnGround { get; set; } = false;
    public bool IsLongJump { get; set; } = false;
    public Vector2 Velocity => rigid2D.velocity;

    private void Awake()
    {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        UpdateJumpHeight();
        UpdateCollision();
    }

    public void MoveTo(float input)
    {
        // if the input == 0.5f, walk. if == 1, run.
        moveSpeed = Mathf.Abs(input) != 1 ? walkSpeed : runSpeed;

        if ( input != 0 ) input = Mathf.Sign(input);

        rigid2D.velocity = new Vector2(moveSpeed * input, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if ( IsOnGround )
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
        }
    }

    private void UpdateJumpHeight()
    {
        if ( IsLongJump )   rigid2D.gravityScale = lowGravityScale;
        else                rigid2D.gravityScale = highGravityScale;
    }

    private void UpdateCollision()
    {
        Bounds bounds = collider.bounds;

        feetPosition = new Vector2(bounds.center.x, bounds.min.y);
        collisionSize = new Vector2(bounds.max.x - bounds.min.x, 0.1f);

        IsOnGround = Physics2D.OverlapBox(feetPosition, collisionSize, 0, groundLayers);
    }
}
