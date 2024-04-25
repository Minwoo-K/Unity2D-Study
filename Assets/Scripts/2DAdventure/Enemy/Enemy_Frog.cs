using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Frog : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayerMask;

    private RigidMovement2D     movement;
    private new Collider2D      collider2D;
    private SpriteRenderer      spriteRenderer;
    private Animator            animator;
    private int                 direction = -1;

    private void Awake()
    {
        movement = GetComponent<RigidMovement2D>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();

        StartCoroutine(Process());
    }

    private IEnumerator Process()
    {
        while ( true )
        {
            yield return StartCoroutine(Idle());

            yield return StartCoroutine(Jump());
        }
    }

    private IEnumerator Idle()
    {
        float idleTime = 2;
        float timer = 0;

        while ( timer < idleTime )
        {
            timer += Time.deltaTime;

            yield return null;
        }
    }

    private IEnumerator Jump()
    {
        movement.Jump();
        animator.SetTrigger("OnJumping");

        while ( !movement.IsOnGround )
        {
            animator.SetFloat("VelocityY", movement.Velocity.y);

            yield return null;
        }

        if ( movement.IsOnGround )
        {
            animator.SetTrigger("OnLanding");
        }
    }

    private void UpdateDirection()
    {
        Bounds bounds = collider2D.bounds;
        Vector2 size = new Vector2(0.1f, (bounds.max.y - bounds.min.y) * 0.8f);
        Vector3 position = new Vector3((direction == -1 ? bounds.min.x : bounds.max.x), bounds.center.y);

        if ( Physics2D.OverlapBox(position, size, 0, groundLayerMask))
        {
            direction *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
