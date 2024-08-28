using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{
    [SerializeField]
    private LayerMask       groundLayer;
    [SerializeField]
    private float           walkSpeed;
    [SerializeField]
    private float           runSpeed;

    private Rigidbody2D     rigid2D;
    private new Collider2D  collider;

    private float           moveSpeed;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        moveSpeed = walkSpeed;
    }

    private void Update()
    {
        
    }

    private void UpdateCollision()
    {

    }
}
