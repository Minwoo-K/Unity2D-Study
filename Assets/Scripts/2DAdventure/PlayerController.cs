using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode;

    private RigidbodyMovement2D movement;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        movement = GetComponent<RigidbodyMovement2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        UpdateSpriteFlipX(xInput);
        float offset = 0.5f + (Input.GetAxis("Run") * 0.5f);
        xInput *= offset;

        movement.Move(xInput);

        UpdateJump();
    }

    private void UpdateSpriteFlipX(float x)
    {
        if (x == 0) return;

        spriteRenderer.flipX = x == 1 ? false : true;
    }

    private void UpdateJump()
    {
        if ( Input.GetKeyDown(jumpKeyCode) )
        {
            movement.Jump();
        }
        else if ( Input.GetKey(jumpKeyCode) )
        {
            movement.IsHigherJump = true;
        }
        else if ( Input.GetKeyUp(jumpKeyCode) )
        {
            movement.IsHigherJump = false;
        }
    }
}
