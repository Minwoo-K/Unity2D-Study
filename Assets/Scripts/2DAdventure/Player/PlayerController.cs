using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode;

    private MovementRigidbody2D movement;
    private Animator animator;

    private void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float offsetX = 0.5f + Input.GetAxisRaw("Run") * 0.5f;
        
        inputX *= offsetX;

        UpdateMove(inputX);
        UpdateJump();
        UpdateAnimation(inputX);
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
        animator.SetFloat("VelocityX", inputX);

        if ( !movement.IsOnGround && movement.Velocity.y != 0 ) 
            animator.SetBool("IsJumping", true);
        else                        
            animator.SetBool("IsJumping", false);

        animator.SetFloat("VelocityY", movement.Velocity.y);
    }
}
