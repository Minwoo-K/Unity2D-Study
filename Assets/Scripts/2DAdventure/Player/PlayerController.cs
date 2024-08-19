using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // SerializeField
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;

    private MovementRigid2D movement;
    private Animator        animator;
    private SpriteRenderer  spriteRenderer;

    private void Awake()
    {
        movement = GetComponent<MovementRigid2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float offset = 0.5f + Input.GetAxisRaw("Run") * 0.5f;
        x *= offset;

        UpdateMove(x);
        UpdateAnimation(x);
        UpdateSprite(x);
        UpdateJump();
    }

    private void UpdateSprite(float input)
    {
        if ( input == 0 ) return;

        spriteRenderer.flipX = input < 0 ? true : false;
    }

    private void UpdateMove(float input)
    {
        movement.MoveTo(input);
    }

    private void UpdateJump()
    {
        if ( Input.GetKeyDown(jumpKeyCode) )
        {
            movement.Jump();
        }
        else if ( Input.GetKey(jumpKeyCode) )
        {
            movement.IsLongJump = true;
        }
        else if ( Input.GetKeyUp(jumpKeyCode) )
        {
            movement.IsLongJump = false;
        }
    }

    private void UpdateAnimation(float input)
    {
        animator.SetFloat("InputX", Mathf.Abs(input));

        animator.SetBool("IsJumping", !movement.IsOnGround);
        animator.SetFloat("VelocityY", movement.Velocity.y);
    }
}
