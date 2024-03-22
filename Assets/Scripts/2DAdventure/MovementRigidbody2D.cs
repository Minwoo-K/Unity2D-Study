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
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    public void MoveInX(float x)
    {
        
    }
}
