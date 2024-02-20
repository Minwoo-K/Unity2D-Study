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
        private new Collider2D collider;
        private Animator animator;
        private SpriteRenderer spriteRenderer;
        private int direction = -1;

        private void Awake()
        {
            movement2D = GetComponent<MovementRigidbody2D>();
            collider = GetComponent<Collider2D>();
            animator = GetComponentInChildren<Animator>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            StartCoroutine(Idle());
        }

        private IEnumerator Idle()
        {
            float waitTime = 2;
            float current = 0;

            while (current < waitTime)
            {
                current += Time.deltaTime;

                yield return null;
            }

            movement2D.Jump();
            animator.SetTrigger("onJump");

            StartCoroutine(Jump());
        }

        private IEnumerator Jump()
        {
            yield return new WaitUntil(() => !movement2D.IsOnGround);

            while (true)
            {
                UpdateDirection();
                movement2D.MoveTo(direction);
                animator.SetFloat("velocityY", movement2D.Velocity.y);

                if (movement2D.IsOnGround)
                {
                    movement2D.MoveTo(0);
                    animator.SetTrigger("onLanding");

                    StartCoroutine(Idle());

                    yield break;
                }
                
                yield return null;
            }


        }

        private void UpdateDirection()
        {
            Bounds bound = collider.bounds;
            Vector2 size = new Vector2(0.1f, (bound.max.y - bound.min.y) * 0.8f);
            Vector2 position = new Vector2((direction == -1 ? bound.min.x : bound.max.x), bound.center.y);

            // If collided with a groundlayer object,
            if (Physics2D.OverlapBox(position, size, 0, groundLayer))
            {
                direction *= -1;
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }

        }

        public override void OnDie()
        {
            if (IsDead) return;

            IsDead = true;

            float fadingTime = 2;
            StartCoroutine(FadeEffect.FadeOn(spriteRenderer, 1, 0, fadingTime));
            Destroy(gameObject, fadingTime);
        }
    }
}
