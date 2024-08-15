using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigid2D : MonoBehaviour
{
    // SereializeFields
    [SerializeField]
    private LayerMask groundLayers;

    [SerializeField]
    private float walkSpeed = 8f;
    [SerializeField]
    private float runSpeed = 13f;

    // Private Variables
    private float moveSpeed;
    private Rigidbody2D rigid2D;

    // Properties
    public bool IsOnGround { get; set; } = false;

    private void Awake()
    {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
    }

    public void MoveTo(float input)
    {
        // if the input == 0.5f, walk. if == 1, run.
        moveSpeed = Mathf.Abs(input) != 1 ? walkSpeed : runSpeed;

        if ( input != 0 ) input = Mathf.Sign(input);

        rigid2D.velocity = new Vector2(moveSpeed * input, rigid2D.velocity.y);
    }
}
