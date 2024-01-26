using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator animator;
        private MovementRigidbody2D movement;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            movement = GetComponentInParent<MovementRigidbody2D>();
        }

        public void UpdateAnimation(float stateCode)
        {
            // Sprite Direction to move right or left
            if ( stateCode != 0 )
            {
                SpriteFlipX(stateCode);
            }

            // -- Animation: Idle | Walk | Run | JumpUp | JumpDown
            
            // Move OR Jump
            animator.SetBool("isJumping", !movement.IsOnGround);

            // Move: Idle, Walk, Run
            if ( movement.IsOnGround )
            {
                animator.SetFloat("velocityX", Mathf.Abs(stateCode));
            }
            // Jump: JumpUp, JumpDown
            else
            {
                animator.SetFloat("velocityY", movement.Velocity.y);
            }
        }

        private void SpriteFlipX(float stateCode)
        {
            transform.parent.localScale = new Vector3((stateCode > 0 ? 1 : -1), 1, 1);
        }
    }
}
