using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mushroom : MonoBehaviour
{
    private FollowPath      followPath;
    private SpriteRenderer  spriteRenderer;
    private Animator        animator;

    private void Awake()
    {
        followPath = GetComponent<FollowPath>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        spriteRenderer.flipX = followPath.Direction == 1 ? true : false;
        animator.SetFloat("MoveSpeed", (int)followPath.State);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            collision.GetComponent<PlayerStat>().DecreaseLife();
        }

        if ( collision.CompareTag("PlayerProjectile") )
        {
            Destroy(collision.gameObject);
            followPath.Stop();
            animator.SetTrigger("IsDead");
        }
    }
}
