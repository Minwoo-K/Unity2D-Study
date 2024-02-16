using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMushroom : MonoBehaviour
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
}
