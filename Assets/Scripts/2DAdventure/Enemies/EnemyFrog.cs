using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class EnemyFrog : EnemyBase
    {
        [SerializeField]
        private LayerMask groundLayer;

        private MovementRigidbody2D movement2D;
        private Animator animator;
        private new Collider2D collider2D;
        private SpriteRenderer spriteRenderer;
        private int direction = -1;

        private void Awake()
        {
            movement2D = GetComponent<MovementRigidbody2D>();
            animator = GetComponentInChildren<Animator>();
            collider2D = GetComponent<Collider2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            StartCoroutine(Idle());
        }

        // Continuous during Idle
        private IEnumerator Idle()
        {
            float waitTime = 2f;

            yield return new WaitForSeconds(waitTime);

            movement2D.Jump();
            animator.SetTrigger("onJumping");

            StartCoroutine(Jump());
        }

        // Continuous during Jumping
        private IEnumerator Jump()
        {
            yield return new WaitUntil(()=> !movement2D.IsOnGround);

            while ( true )
            {
                UpdateDirection();
                movement2D.MoveTo(direction);
                animator.SetFloat("velocityY", movement2D.Velocity.y);

                if ( movement2D.IsOnGround )
                {
                    movement2D.MoveTo(0);
                    animator.SetTrigger("onLanding");
                    StartCoroutine(Idle());

                    yield break;
                }

                yield return null;
            }
        }

        // Continuous during jumping
        private void UpdateDirection()
        {
            Bounds bound = collider2D.bounds;
            Vector2 size = new Vector2(0.1f, (bound.max.y - bound.min.y) * 0.8f);
            Vector2 position = new Vector2((direction == 1 ? bound.max.x : bound.min.x), bound.center.y);

            if ( Physics2D.OverlapBox(position, size, 0, groundLayer) )
            {
                direction *= -1;
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }

        public override void OnDie()
        {
            if ( IsDead ) return;

            IsDead = true;

            StopAllCoroutines();
            float fadeTime = 2;
            StartCoroutine(FadeEffect.FadeOn(spriteRenderer, 1, 0, fadeTime));
            Destroy(gameObject, fadeTime);
        }
    }
}
