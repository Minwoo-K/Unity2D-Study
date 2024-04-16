using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKey;
    [SerializeField]
    private KeyCode weaponFireKey;

    private PlayerStat playerStat;
    private RigidMovement2D movement;
    private PlayerWeapon weapon;
    private Animator animator;
    private float       lastDirectionX;

    private void Awake()
    {
        playerStat  = GetComponent<PlayerStat>();
        movement    = GetComponent<RigidMovement2D>();
        weapon      = GetComponent<PlayerWeapon>();
        animator    = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // Input from Left/Right Arrows (value returned: -1 / +1)
        float xInput = Input.GetAxisRaw("Horizontal");
        // Input from the Run key registered in the ProjectSettings (value returned: 0 / +1)
        float runInput = Input.GetAxisRaw("Run");
        // To polish the input and make it a state, Walk/Run 
        float offset = 0.5f + runInput*0.5f;
        // To make the input be defined to a state
        xInput *= offset;
        // Command movement according to the input
        movement.Move(xInput);

        if ( xInput != 0 ) lastDirectionX = xInput;

        // Jump
        UpdateJump();

        // Animation
        UpdateAnimation(Mathf.Abs(xInput));

        UpdateFlipX(xInput);

        UpdateCollision();

        UpdateFireWeapon();
    }

    private void ResetVelocityY()
    {
        movement.ResetVelocityY();
    }

    // Branched Update Methods
    private void UpdateJump()
    {
        if ( Input.GetKeyDown(jumpKey) )
        {
            movement.Jump();
        }
        else if ( Input.GetKey(jumpKey) )
        {
            movement.IsHigherJump = true;
        }
        else if ( Input.GetKeyUp(jumpKey) )
        {
            movement.IsHigherJump = false;
        }
    }

    private void UpdateAnimation(float x)
    {
        animator.SetFloat("velocityX", x);

        if ( ! movement.IsOnGround )
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        animator.SetFloat("velocityY", movement.Velocity.y);
    }

    private void UpdateFlipX(float x)
    {
        if ( x != 0 ) transform.localScale = new Vector3(Mathf.Sign(x), 1, 1);
    }

    private void UpdateCollision()
    {
        if ( movement.HeadCollision != null && movement.Velocity.y >= 0 )
        {
            ResetVelocityY();
            if ( movement.HeadCollision.TryGetComponent<Tile_Base>(out var tile) && ! tile.IsHit )
            {
                tile.UponCollision();
            }
        }

        if ( movement.FeetCollision != null && movement.IsOnGround )
        {
            if (movement.FeetCollision.TryGetComponent<Platform_Base>(out var platform))
            {
                platform.UponCollision(gameObject);
            }
        }
    }

    private void UpdateFireWeapon()
    {
        if ( Input.GetKeyDown(weaponFireKey) )
        {
            weapon.FireProjectile(lastDirectionX);
        }
    }
}
