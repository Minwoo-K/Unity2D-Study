using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class MovementRigidbody2D : MonoBehaviour
    {
        [Header("LayerMask")]
        [SerializeField]
        private LayerMask groundCheckLayer;         // Layer to check whether the player is on the ground or not
        [SerializeField]
        private LayerMask headCollisionLayer;       // Layer that can collide with the player's head

        [Header("Move")]
        [SerializeField]
        private float walkSpeed = 5;                // Speed when walking
        [SerializeField]
        private float runSpeed = 8;                 // Speed when running

        [Header("Jump")]
        [SerializeField]
        private float jumpForce = 15;               // A Force for jumping
        [SerializeField]
        private float lowGravityScale = 2;          // Gravity Scale value for longer jump
        [SerializeField]
        private float highGravityScale = 3.5f;      // Gravity Scale value for shorter jump

        private float moveSpeed;                    // Move Speed

        // To be able to jump when jump was commanded right before(within the jumpBufferTime) landing on ground
        private float jumpBufferTime = 0.1f;
        private float jumpBufferCounter;

        // To be able to still jump within the time where the player is off of ground
        private float hangingTime = 0.2f;
        private float hangingCounter;

        private Vector2 collisionSize;              // CollisionSize on the player's head and feet
        private Vector2 feetPosition;               // Player's feet position
        private Vector2 headPosition;               // Player's head position

        private Rigidbody2D rigid2D;                // Rigidbody2D component
        private Collider2D collider2D;              // Collider2D component

        public bool IsLongerJump { get; set; } = false;         // Check for a Jump to be longer or regular
        public bool IsOnGround { get; private set; } = false;   // Check whether the player is on ground
        public Collider2D colliderOnHead { get; private set;}   // The object that collides with the player on its head

        public Vector2 Velocity => rigid2D.velocity;

        private void Awake()
        {
            moveSpeed = walkSpeed;

            rigid2D = GetComponent<Rigidbody2D>();
            collider2D = GetComponent<Collider2D>();
        }

        private void Update()
        {
            UpdateCollision();
            JumpHeight();
            JumpAdditive();
        }

        /// <summary>
        /// Setting X axis velocity
        /// </summary>
        public void MoveTo(float x)
        {
            // if the absolute value of x == 0.5, walk. == 1, run
            moveSpeed = Mathf.Abs(x) != 1 ? walkSpeed : runSpeed;

            // if x is a decimal value(-0.5, 0.5), change it to -1 or 1
            if ( x != 0 ) x = Mathf.Sign(x);

            // This line eventually moves the gameObject
            rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
        }

        private void UpdateCollision()
        {
            // Fetch the player object's Collider2D bounds
            Bounds bounds = collider2D.bounds;

            // Collision Range on the Player's feet
            collisionSize = new Vector2((bounds.max.x - bounds.min.x) * 0.5f, 0.1f);

            // Set head/feet collider position based on the bounds
            headPosition = new Vector2(bounds.center.x, bounds.max.y);
            feetPosition = new Vector2(bounds.center.x, bounds.min.y);

            // Create a Collision box to check if player is on ground
            // If the player is on ground, the function returns true, otherwise false
            IsOnGround = Physics2D.OverlapBox(feetPosition, collisionSize, 0, groundCheckLayer);

            // If collides, the object's collider component is stored. Otherwise, null
            colliderOnHead = Physics2D.OverlapBox(headPosition, collisionSize, 0, headCollisionLayer);
        }

        // Y axis Jump command
        public void Jump()
        {
            jumpBufferCounter = jumpBufferTime;
        }

        private void JumpHeight()
        {
            // Longer Jump as setting the gravity scale lower
            if (IsLongerJump && rigid2D.velocity.y > 0)
            {
                rigid2D.gravityScale = lowGravityScale;
            }
            // Shorter Jump as setting the gravity scale higher
            else
            {
                rigid2D.gravityScale = highGravityScale;
            }
        }

        private void JumpAdditive()
        {
            if ( IsOnGround ) hangingCounter = hangingTime;
            else              hangingCounter = hangingCounter -= Time.deltaTime;

            if ( jumpBufferCounter > 0 )
            {
                jumpBufferCounter -= Time.deltaTime;
            }

            if ( jumpBufferCounter > 0 && hangingCounter > 0 )
            {
                rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
                jumpBufferCounter = 0;
                hangingCounter = 0;
            }
        }

        public void CancelVelocityY()
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
        }
    }

}
