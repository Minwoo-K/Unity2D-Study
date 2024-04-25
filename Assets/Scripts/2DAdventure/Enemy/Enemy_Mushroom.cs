using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mushroom : Enemy_Base
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

    public override void OnDead()
    {
        if ( IsDead ) return;

        IsDead = true;
        followPath.Stop();
        animator.SetTrigger("IsDead");
    }

}
