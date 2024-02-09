using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PlayerProjectile : MonoBehaviour
    {
        private MovementRigidbody2D movement;   // To initially make the Projectile move
        private float originalSpeedX;            // Original Speed to track of in X axis


        public void Setup(int direction)
        {
            movement = GetComponent<MovementRigidbody2D>();
            movement.MoveTo(direction);

            originalSpeedX = Mathf.Abs(movement.Velocity.x);
        }

        private void Update()
        {
            // If Projectile hits ground, it jumps
            if ( movement.IsOnGround ) movement.Jump();
            // If the Projectile's velocity reduces, it's assumed that it's collided with something(that's not a ground-kind)
            if ( Mathf.Abs(movement.Velocity.x) < originalSpeedX )
            {
                Destroy(gameObject);
            }

            // If this Projectile falls to void, destroy it
            if ( transform.position.y < -50 ) Destroy(gameObject);
        }
    }
}


