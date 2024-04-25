using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Frog : Enemy_Base
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

        yield return new WaitUntil(()=> !movement.IsOnGround);

        while ( true )
        {
            UpdateDirection();
            movement.Move(direction);
            animator.SetFloat("VelocityY", movement.Velocity.y);
            
            if (movement.IsOnGround)
            {
                movement.Move(0);
                animator.SetTrigger("OnLanding");

                yield break;
            }

            yield return null;
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

    public override void OnDead()
    {
        if (IsDead) return;

        IsDead = true;
        StopAllCoroutines();
        float fadeTime = 2f;
        StartCoroutine(FadingEffect.FadeOn(spriteRenderer, 1, 0, fadeTime));
        
        Destroy(gameObject, fadeTime);
    }
}
