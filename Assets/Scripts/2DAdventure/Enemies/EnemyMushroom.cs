using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMushroom : EnemyBase
{
    private PathDrawer     pathDrawer;
    private SpriteRenderer spriteRenderer;
    private Animator       animator;

    private void Awake()
    {
        pathDrawer = GetComponent<PathDrawer>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        spriteRenderer.flipX = pathDrawer.Direction == 1 ? true : false;
        animator.SetFloat("moveSpeed", (int)pathDrawer.pathMode_State);
    }

    public override void OnDie()
    {
        pathDrawer.Stop();
        animator.SetTrigger("OnDie");
    }
}
