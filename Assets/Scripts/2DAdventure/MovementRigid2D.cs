using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigid2D : MonoBehaviour
{
    [Header("Layer Check")]
    [SerializeField]
    private LayerMask groundLayer;          // LayerMasks to check if the object is on ground

    [Header("Movement")]
    [SerializeField]
    private float walkSpeed = 5;            // Moving speed when walking
    [SerializeField]
    private float runSpeed = 8;             // Moving speed when running

    [Header("Jumping")]
    [SerializeField]
    private float jumpForce = 13f;          // Force onto the Rigidbody2D when jumping
    [SerializeField]
    private float lowGravityScale = 2f;     // Short Jump
    [SerializeField]
    private float highGravityScale = 3.5f;  // Long Jump

    // Fundamental Variables
    private float moveSpeed;                // The moving speed of this object

    private Vector2 collisionSize;          // Size of the object's collision
    private Vector2 headPosition;           // Position of its head
    private Vector2 feetPosition;           // Position of its feet

    private Rigidbody2D rigid2D;            // Rigidbody2D component on this object
    private Collider2D collider2D;          // Collider component on this object

    // Public
    public bool IsLongJump { set; get; } = false; // A switch to turn on when long jump
    public bool IsOnGround { set; get; } = false; // A switch to turn on when on ground

    private void Awake()
    {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    public void MoveTo(float x)
    {
        // if Absolute value of x is 0.5, walking. if 1, running
    }
}
