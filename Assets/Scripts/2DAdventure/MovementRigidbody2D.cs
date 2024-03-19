using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{
    // SERIALIZEFILED
    [Header("Layer Masks")]
    [SerializeField]
    private LayerMask groundCheckLayer;
    [SerializeField]
    private LayerMask headCollisionLayer;
    [SerializeField]
    private LayerMask feetCollisionLayer;

    [Header("Move")]
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;

    [Header("Jump")]
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float lowGravityScale;
    [SerializeField]
    private float highGravityScale;

    // PRIVATE VARIABLES
    private float moveSpeed;

    private Vector2 collisionSize;
    private Vector2 feetPosition;
    private Vector2 headPosition;

    private Rigidbody2D rigid2D;
    private new Collider2D collider2D;

    // PROPERTIES
    public bool IsHigherJump { get; set; } = false;
    public bool IsOnGround   { get; set; } = false;
    public Collider2D headCollision { get; private set; }
    public Collider2D feetCollision { get; private set; }

    public Vector2 Velocity => rigid2D.velocity;

    private void Awake()
    {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        UpdateJumpHeight();
        UpdateCollision();
    }

    public void MoveTo(float x)
    {
        moveSpeed = Mathf.Abs(x) != 1 ? walkSpeed : runSpeed;

        if ( x != 0 ) x = Mathf.Sign(x);

        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if ( IsOnGround )
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
        }
    }

    // Set up Jump Height in the Update function
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
        Bounds bounds = collider2D.bounds;

        collisionSize = new Vector2((bounds.max.x - bounds.min.x)*0.5f, 0.1f);

        feetPosition = new Vector2(bounds.center.x, bounds.min.y);
        headPosition = new Vector2(bounds.center.x, bounds.max.y);

        IsOnGround = Physics2D.OverlapBox(feetPosition, collisionSize, 0, groundCheckLayer);

        headCollision = Physics2D.OverlapBox(headPosition, collisionSize, 0, headCollisionLayer);
        feetCollision = Physics2D.OverlapBox(feetPosition, collisionSize, 0, feetCollisionLayer);
    }

    public void ResetVelocityY()
    {
        rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
    }
}
