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
    private SpriteRenderer  spriteRenderer;
    private Animator        animator;

    private void Awake()
    {
        movement = GetComponent<MovementRigid2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float offset = 0.5f + Input.GetAxisRaw("Run") * 0.5f;
        x *= offset;

        UpdateMove(x);
        UpdateSprite(x);
        UpdateJump();
        UpdateAnimation(x);
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
        animator.SetFloat("Input", Mathf.Abs(input));

        if ( movement.IsOnGround )  animator.SetBool("IsJumping", false);
        else                        animator.SetBool("IsJumping", true);

        animator.SetFloat("VelocityY", movement.Velocity.y);
    }
}
