using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private MovementRigidbody2D movement;
    private Animator animator;

    private void Awake()
    {
        movement = GetComponentInParent<MovementRigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void UpdateAnimation(float x)
    {
        x = Mathf.Abs(x);
        animator.SetFloat("MovementParameter", x);

        animator.SetBool("isJumping", !movement.IsOnGround);

        if ( !movement.IsOnGround )
        {
            animator.SetFloat("velocityY", movement.Velocity.y);
        }
    }
}
