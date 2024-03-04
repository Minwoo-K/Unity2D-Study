using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{
    // SERIALIZEFILED
    [Header("Layer Masks")]
    [SerializeField]
    private LayerMask groundLayerCheck;

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

    }
}
