using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private StageData stageData;
        [SerializeField]
        private KeyCode jumpKeyCode = KeyCode.Space;

        private MovementRigidbody2D movement;
        private PlayerAnimator playerAnimator;

        private void Awake()
        {
            movement = GetComponent<MovementRigidbody2D>();
            playerAnimator = GetComponentInChildren<PlayerAnimator>();
        }

        private void Update()
        {
            // Key Input (Left/Right direction keys & Left-Ctrl Key)
            // This activates the direction keys & A/D keys to behave for the player to move
            // Key A/Left Direction, return -1 & Key D/Right Direction, return 1
            float x = Input.GetAxisRaw("Horizontal");

            // Input.GetAxisRaw("Sprint"): when the set-up key is pressed, it returns 1
            float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f;

            // When walking, x is within -0.5 ~ 0.5
            // When running, x is within -1 ~ 1
            x *= offset;

            // Player's move (L/R)
            UpdateMove(x);
            // Player's Jump
            UpdateJump();
            // Animation
            playerAnimator.UpdateAnimation(x);
            // Head Collision
            UpdateCollision();
        }

        private void UpdateMove(float x)
        {
            // Movement in X axis (left - right)
            movement.MoveTo(x);
            // Limiting the player's movement range within the game world
            float limitX = Mathf.Clamp(transform.position.x, stageData.PlayerLimitMinX, stageData.PlayerLimitMaxX);
            transform.position = new Vector3(limitX, transform.position.y);
        }

        private void UpdateJump()
        {
            if ( Input.GetKey(jumpKeyCode) )
            {
                movement.Jump();
            }

            // while pressing the Jump key
            if ( Input.GetKey(jumpKeyCode) )
            {
                movement.IsLongerJump = true;
            }
            // when the key is up, done being pressed
            else if ( Input.GetKeyUp(jumpKeyCode) )
            {
                movement.IsLongerJump = false;
            }
        }

        private void UpdateCollision()
        {
            // If colliding with an object on the head while jumping,
            if ( movement.Velocity.y >= 0 && movement.colliderOnHead != null )
            {
                // cancel the jumpForce
                movement.CancelVelocityY();
            }
        }
    }
}
