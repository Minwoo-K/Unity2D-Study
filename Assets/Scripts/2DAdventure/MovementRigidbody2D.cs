using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{
    // SERIALIZEFILED
    [Header("Layer Masks")]
    [SerializeField]
    private LayerMask groundCheckLayer;

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

    private Rigidbody2D rigid2D;
    private Collider2D collider2D;

    // PROPERTIES
    public bool IsHigherJump { get; set; } = false;
    public bool IsOnGround   { get; set; } = false;

    private void Awake()
    {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    public void MoveTo(float x)
    {
        moveSpeed = Mathf.Abs(x) != 1 ? walkSpeed : runSpeed;

        if ( x != 0 ) x = Mathf.Sign(x);

        Debug.Log($"x value: {x} -> Mathf.Sign(x): {Mathf.Sign(x)}");

        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    public void Jump()
    {

    }

    public void JumpHeight()
    {

    }

    private void UpdateCollision()
    {
        Bounds bounds = collider2D.bounds;

        collisionSize = new Vector2((bounds.max.x - bounds.min.x)*0.5f, 0.1f);

        feetPosition = new Vector2(bounds.center.x, bounds.min.y);

        IsOnGround = Physics2D.OverlapBox(feetPosition, collisionSize, 0, groundCheckLayer);
    }
}
