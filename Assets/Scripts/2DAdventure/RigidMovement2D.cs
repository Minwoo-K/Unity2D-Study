using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMovement2D : MonoBehaviour
{
    [Header("Layer Management")]
    [SerializeField]
    private LayerMask   groundCheckLayer;

    [Header("Movement")]
    [SerializeField]
    private float       walkSpeed;
    [SerializeField]
    private float       runSpeed;

    [Header("Jump")]
    [SerializeField]
    private float       jumpForce;
    [SerializeField]
    private float       lowGravityScale;
    [SerializeField]
    private float       highGravityScale;

    private float           moveSpeed;
    private Rigidbody2D     rigid2D;
    private new Collider2D  collider;
    private Bounds          bounds;
    private Vector2         collisionSize;
    private Vector2         headPosition;

    public bool         IsHigherJump { get; set; }
    public bool         IsOnGround  { get; private set; }
    

    private void Awake()
    {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        bounds = collider.bounds;
    }

    private void Update()
    {
        UpdateJumpHeight();
        UpdateCollision();
    }

    public void Move(float xInput)
    {
        // xInput, 0: Idle / 0.5: Walk / 1: Run
        moveSpeed = Mathf.Abs(xInput) != 1 ? walkSpeed : runSpeed;

        if ( xInput != 0 ) xInput = Mathf.Sign(xInput);

        rigid2D.velocity = new Vector2(xInput * moveSpeed, rigid2D.velocity.y);
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
        if ( IsHigherJump && ! IsOnGround )
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
        collisionSize = new Vector2((bounds.max.x - bounds.min.x) / 2f, 0.1f);

        IsOnGround = Physics2D.OverlapBox(headPosition, collisionSize, 0, groundCheckLayer);
    }
}
