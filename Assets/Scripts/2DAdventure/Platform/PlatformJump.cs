using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PlatformJump : PlatformBase
    {
        [SerializeField]
        private float jumpForce = 22;
        [SerializeField]
        private float resetTime = 0.5f;

        private Animator animator;
        private GameObject other;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public override void UpdateCollision(GameObject other)
        {
            if ( IsHit == true ) return;

            IsHit = true;
            this.other = other;

            animator.SetTrigger("OnJump");
        }

        public void JumpAction()
        {
            other.GetComponent<MovementRigidbody2D>().JumpUp(jumpForce);
            other = null;

            Invoke(nameof(Reset), resetTime); // Call the function "Reset" in(after) the resetTime
        }

        private void Reset()
        {
            IsHit = false;   
        }
    }
}
