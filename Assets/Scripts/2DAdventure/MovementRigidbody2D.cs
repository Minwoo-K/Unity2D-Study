using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{
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


    private float moveSpeed;
    private Rigidbody2D rigid2D;

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
}
