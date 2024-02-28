using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private GameManager gameManager;
        [SerializeField]
        private KeyCode jumpKeyCode = KeyCode.Space;
        [SerializeField]
        private KeyCode fireKeyCode = KeyCode.Z;

        private StageData stageData;
        private MovementRigidbody2D movement;
        private PlayerAnimator playerAnimator;
        private PlayerWeapon weapon;
        private PlayerData playerData;
        private int lastDirectionX = 1;

        public void Setup(StageData stageData)
        {
            this.stageData = stageData;
            transform.position = stageData.PlayerPosition;
        }

        private void Awake()
        {
            movement = GetComponent<MovementRigidbody2D>();
            playerAnimator = GetComponentInChildren<PlayerAnimator>();
            weapon = GetComponent<PlayerWeapon>();
            playerData = GetComponent<PlayerData>();
        }

        private void Update()
        {
            // Key Input (Left/Right direction keys & Left-Ctrl Key)
            // This activates the direction keys & A/D keys to behave for the player to move
            // Key A/Left Direction, return -1 & Key D/Right Direction, return 1
            float x = Input.GetAxisRaw("Horizontal");

            // Input.GetAxisRaw("Sprint"): when the set-up key is pressed, it returns 1
            float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f;

            if ( x != 0 ) lastDirectionX = (int)x;

            // When walking, x is within -0.5 ~ 0.5
            // When running, x is within -1 ~ 1
            x *= offset;

            // Player's move (L/R)
            UpdateMove(x);
            // Player's Jump
            UpdateJump();
            // Animation
            playerAnimator.UpdateAnimation(x);
            // Collsion Update
            UpdateCollisionAbove();
            UpdateCollisionBelow();
            // Projectile Update
            UpdateProjectileAttack();
            // Check if Player has fallen under ground
            IsUnderGround();
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

        // Collision on its HEAD
        private void UpdateCollisionAbove()
        {
            if ( movement.Velocity.y >= 0 && movement.colliderOnHead != null )
            {
                movement.CancelVelocityY();

                if ( movement.colliderOnHead.TryGetComponent<TileBase>(out var tile) && tile.IsHit == false )
                {
                    tile.UpdateCollsion();
                }
            }
        }

        // Collision on its FEET
        private void UpdateCollisionBelow()
        {
            if ( movement.colliderOnFeet != null )
            {
                if ( Input.GetKeyDown(KeyCode.DownArrow) && movement.colliderOnFeet.TryGetComponent<PlatformEffectorExtension>(out var p))
                {
                    p.OnDownWay();
                }

                if ( movement.colliderOnFeet.TryGetComponent<PlatformBase>(out var platform) )
                {
                    platform.UpdateCollision(gameObject);
                }
            }
        }

        private void UpdateProjectileAttack()
        {
            if ( Input.GetKeyDown(fireKeyCode) && playerData.CurrentProjectile > 0 )
            {
                playerData.CurrentProjectile --;
                weapon.FireProjectile(lastDirectionX);
            }
        }
        
        private void IsUnderGround()
        {
            if ( transform.position.y < stageData.MapLimitMinY )
            {
                gameManager.OnDie();
            }
        }

        public void OnDie()
        {
            gameManager.OnDie();
        }

        public void LevelComplete()
        {
            gameManager.LevelComplete();
        }
    }
}
