using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMovement2D : MonoBehaviour
{
    [Header("Layer Management")]
    [SerializeField]
    private LayerMask groundCheckLayer;

    [Header("Movement")]
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;

    private float moveSpeed;

    public Rigidbody2D rigid2D { get; private set; }

    private void Awake()
    {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float xInput)
    {
        // xInput, 0: Idle / 0.5: Walk / 1: Run
        moveSpeed = Mathf.Abs(xInput) != 1 ? walkSpeed : runSpeed;

        if ( xInput != 0 ) xInput = Mathf.Sign(xInput);

        rigid2D.velocity = new Vector2(xInput * moveSpeed, rigid2D.velocity.y);
    }
}
