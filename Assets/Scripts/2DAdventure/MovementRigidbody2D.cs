using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{
    [Header("LayerMasks")]
    [SerializeField]
    private LayerMask       groundLayer;
    
    [Header("Movement")]
    [SerializeField]
    private float           walkSpeed;
    [SerializeField]
    private float           runSpeed;

    [Header("Jump")]
    [SerializeField]
    private float           jumpForce;
    [SerializeField]
    private float           lowGravityScale;
    [SerializeField]
    private float           highGravityScale;

    private Rigidbody2D     rigid2D;
    private new Collider2D  collider;

    private float           moveSpeed;

    private Vector2 headPosition;
    private Vector2 feetPosition;
    private Vector2 collisionSize;

    public bool IsOnGround { get; private set; } = false;
    public Vector2 Velocity => rigid2D.velocity;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        collider = GetComponentInChildren<Collider2D>();
        moveSpeed = walkSpeed;
        rigid2D.gravityScale = lowGravityScale;
    }

    private void Update()
    {
        UpdateCollision();
    }

    private void UpdateCollision()
    {
        Bounds bounds = collider.bounds;
        collisionSize = new Vector2((bounds.max.x - bounds.min.x)*0.75f, 0.1f);
        headPosition = new Vector2(bounds.center.x, bounds.max.y);
        feetPosition = new Vector2(bounds.center.x, bounds.min.y);

        IsOnGround = Physics2D.OverlapBox(feetPosition, collisionSize, 0, groundLayer);
    }

    public void MoveTo(float x)
    {
        rigid2D.velocity = new Vector2(moveSpeed * x, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if ( IsOnGround )
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
        }
    }
}
