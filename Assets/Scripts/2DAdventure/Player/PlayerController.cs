using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageData   stageData;
    [SerializeField]
    private KeyCode     jumpKeyCode;
    [SerializeField]
    private KeyCode     shootingKeyCode;

    private RigidbodyMovement2D movement;
    private SpriteRenderer      spriteRenderer;
    private Animator            animator;
    private PlayerWeapon        weapon;
    private bool                wasOnGround = true;
    private int                 lastDirectionX = 1;

    private void Awake()
    {
        movement = GetComponent<RigidbodyMovement2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        weapon = GetComponent<PlayerWeapon>();
    }

    private void Update()
    {
        // Movement
        float xInput = Input.GetAxisRaw("Horizontal");
        UpdateSpriteFlipX(xInput);
        float offset = 0.5f + (Input.GetAxis("Run") * 0.5f);
        
        if ( xInput != 0) lastDirectionX = (int)xInput;

        xInput *= offset;
        movement.Move(xInput);

        float x = Mathf.Clamp(transform.position.x, stageData.PlayerMinLimitX, stageData.PlayerMaxLimitX);
        transform.position = new Vector3(x, transform.position.y, 0);

        // Animation
        UpdateAnimation(xInput);

        // Jump
        UpdateJump();

        // Shooting a Projectile
        UpdateAttack(lastDirectionX);
    }

    private void UpdateSpriteFlipX(float x)
    {
        if (x == 0) return;

        spriteRenderer.flipX = x == 1 ? false : true;
    }

    private void UpdateJump()
    {
        if ( Input.GetKeyDown(jumpKeyCode) )
        {
            movement.Jump();
        }
        else if ( Input.GetKey(jumpKeyCode) )
        {
            movement.IsHigherJump = true;
        }
        else if ( Input.GetKeyUp(jumpKeyCode) )
        {
            movement.IsHigherJump = false;
        }
    }

    private void UpdateAnimation(float x)
    {
        animator.SetFloat("VelocityX", Mathf.Abs(x));

        if ( wasOnGround && !movement.IsOnGround )
        {
            animator.SetBool("IsJumping", true);
        }

        wasOnGround = movement.IsOnGround;

        if ( movement.IsOnGround )
        {
            animator.SetBool("IsJumping", false);
        }

        animator.SetFloat("VelocityY", movement.Velocity.y);
    }

    private void UpdateAttack(float x)
    {
        if (Input.GetKeyDown(shootingKeyCode))
        {
            weapon.ShootProjectile(x);
        }
    }
}
