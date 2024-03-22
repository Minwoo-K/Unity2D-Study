using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundCheckLayers;

    [Header("Movement")]
    [SerializeField]
    private float walkSpeed;        // Speed in walking
    [SerializeField]
    private float runSpeed;         // Speed in running

    [Header("Jump")]
    [SerializeField]
    private float jumpForce;        // Basic Jump Force
    [SerializeField]
    private float lowGravityScale;  // Gravity Scale in Higher Jump
    [SerializeField]
    private float highGravityScale; // Gravity Scale in Basic Jump

    // Private Variables
    private Rigidbody2D rigid2D;
    private float moveSpeed;
    private new Collider2D collider;
    private Vector2 feetPosition;
    private Vector2 collisionSize;
    
    // Properties
    public bool IsOnGround { get; private set;} = false;
    public bool IsHigherJump { get; set; } = false;

    private void Awake()
    {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        UpdateCollision();
        UpdateJumpHeight();
    }

    public void MoveInX(float x)
    {
        // x should be either 0, 0.5, or 1
        moveSpeed = Mathf.Abs(x) != 1 ? walkSpeed : runSpeed;

        if (x != 0) x = Mathf.Sign(x);

        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if ( IsOnGround )
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
        }
    }

    public void UpdateJumpHeight()
    {
        if ( IsHigherJump && !IsOnGround )
        {
            rigid2D.gravityScale = lowGravityScale;
        }
        else
        {
            rigid2D.gravityScale = highGravityScale;
        }
    }

    private void UpdateCollision()
    {
        Bounds bounds = collider.bounds;
        collisionSize = new Vector2((bounds.max.x - bounds.min.x) * 0.5f, 0.1f);
        feetPosition = new Vector2(bounds.center.x, bounds.min.y);

        IsOnGround = Physics2D.OverlapBox(feetPosition, collisionSize, 0, groundCheckLayers);
        
    }
}
