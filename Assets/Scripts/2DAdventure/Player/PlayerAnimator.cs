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
        if (x != 0)
        {
            SpriteFlipX(x);
        }

        animator.SetBool("isJumping", !movement.IsOnGround);

        // If Jumping
        if ( !movement.IsOnGround )
        {
            animator.SetFloat("velocityY", movement.Velocity.y);
        }
        else // If moving on the ground
        {
            animator.SetFloat("MovementParameter", Mathf.Abs(x));
        }
    }

    private void SpriteFlipX(float x)
    {
        transform.localScale = new Vector3((x > 0 ? 1 : -1), 1, 1);
    }
}
