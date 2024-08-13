using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigid2D : MonoBehaviour
{
    [Header("Layer Check")]
    [SerializeField]
    private LayerMask groundLayer;          // LayerMasks to check if the object is on ground

    [Header("Movement")]
    [SerializeField]
    private float walkSpeed = 5;            // Moving speed when walking
    [SerializeField]
    private float runSpeed = 8;             // Moving speed when running

    [Header("Jumping")]
    [SerializeField]
    private float jumpForce = 13f;          // Force onto the Rigidbody2D when jumping
    [SerializeField]
    private float lowGravityScale = 2f;     // Short Jump
    [SerializeField]
    private float highGravityScale = 3.5f;  // Long Jump

    // Fundamental Variables
    private float moveSpeed;                // The moving speed of this object

    private Vector2 collisionSize;          // Size of the object's collision
    private Vector2 headPosition;           // Position of its head
    private Vector2 feetPosition;           // Position of its feet

    private Rigidbody2D rigid2D;            // Rigidbody2D component on this object
    private Collider2D collider2D;          // Collider component on this object

    // Public
    public bool IsHigherJump { set; get; } = false; // A switch to turn on when long jump
    public bool IsOnGround { set; get; } = false; // A switch to turn on when on ground

    private void Awake()
    {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        UpdateCollision();
        UpdateJumpHeight();
    }

    public void MoveTo(float x)
    {
        // if Absolute value of x is 0.5, walking. if 1, running
        moveSpeed = Mathf.Abs(x) != 1 ? walkSpeed : runSpeed;

        if ( x != 0 ) x = Mathf.Sign(x);

        rigid2D.velocity = new Vector2(moveSpeed * x, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if ( IsOnGround )
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
        }
    }

    private void UpdateCollision()
    {
        Bounds bounds = collider2D.bounds;

        headPosition = new Vector2(bounds.center.x, bounds.max.y);
        feetPosition = new Vector2(bounds.center.x, bounds.min.y);

        collisionSize = new Vector2((bounds.max.x - bounds.min.x) * 0.5f, 0.1f);

        IsOnGround = Physics2D.OverlapBox(feetPosition, collisionSize, 0, groundLayer);
        Debug.Log($"IsOnGround: {IsOnGround}");
    }

    public void UpdateJumpHeight()
    {
        if ( IsHigherJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = lowGravityScale;
        }
        else
        {
            rigid2D.gravityScale = highGravityScale;
        }
    }
}
