using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode;

    private MovementRigidbody2D movement;
    private SpriteRenderer sprite;
    private Animator animator;

    private void Awake()
    {
        // Get Component
        movement = GetComponent<MovementRigidbody2D>();

        // Get Component in the object's children
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float offsetX = 0.5f + Input.GetAxisRaw("Run") * 0.5f;
        
        inputX *= offsetX;

        UpdateFlipX(inputX);
        UpdateMove(inputX);
        UpdateJump();
        UpdateAnimation(inputX);
    }

    private void UpdateFlipX(float inputX)
    {
        if ( inputX < 0 )       sprite.flipX = true;
        else if ( inputX > 0 )  sprite.flipX = false;
    }

    private void UpdateMove(float inputX)
    {
        movement.MoveTo(inputX);
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

    private void UpdateAnimation(float inputX)
    {
        animator.SetFloat("VelocityX", Mathf.Abs(inputX));

        if ( !movement.IsOnGround && movement.Velocity.y != 0 ) 
            animator.SetBool("IsJumping", true);
        else
            animator.SetBool("IsJumping", false);

        animator.SetFloat("VelocityY", movement.Velocity.y);
    }
}
