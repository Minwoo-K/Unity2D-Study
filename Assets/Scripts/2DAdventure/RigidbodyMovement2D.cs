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

    private float moveSpeed;
    
    private Rigidbody2D rigid2D;
    private new Collider2D collider2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        moveSpeed = walkSpeed;
    }

    public void Move(float xInput)
    {
        rigid2D.velocity = new Vector2(xInput * moveSpeed, rigid2D.velocity.y);
    }
}
