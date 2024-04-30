using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement2D : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundCheckLayer;

    [Header("Movement")]
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

    private float moveSpeed;
    
    private Rigidbody2D rigid2D;
    private new Collider2D collider2D;

    public bool IsHigherJump { get; set; } = false;
    public bool IsOnGround { get; private set; } = true;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        moveSpeed = walkSpeed;
    }

    private void Update()
    {
        UpdateJumpHeight();
        UpdateCollisionBelow();
    }

    public void Move(float xInput)
    {
        // (xInput) 0: Idle / 0.5: Walk / 1: Run
        moveSpeed = Mathf.Abs(xInput) == 1 ? runSpeed : walkSpeed;

        if ( xInput != 0 ) xInput = Mathf.Sign(xInput);

        rigid2D.velocity = new Vector2(xInput * moveSpeed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
    }

    private void UpdateJumpHeight()
    {
        rigid2D.gravityScale = IsHigherJump ? lowGravityScale : highGravityScale;
    }

    private void UpdateCollisionBelow()
    {
        Bounds bounds = collider2D.bounds;
        Vector2 position = new Vector2(bounds.center.x, bounds.min.y);
        Vector2 size = new Vector2((bounds.max.x - bounds.min.x), 0.1f);

        IsOnGround = Physics2D.OverlapBox(position, size, 0, groundCheckLayer);
    }
}
