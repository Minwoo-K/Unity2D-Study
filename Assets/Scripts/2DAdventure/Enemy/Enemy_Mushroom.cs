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

}
