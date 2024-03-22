using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundCheckLayers;

    [Header("Movement")]
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;

    private Rigidbody2D rigid2D;
    private float moveSpeed;

    private void Awake()
    {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    public void MoveInX(float x)
    {
        // x should be either 0, 0.5, or 1
        moveSpeed = Mathf.Abs(x) != 1 ? walkSpeed : runSpeed;

        if (x != 0) x = Mathf.Sign(x);

        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }
}
