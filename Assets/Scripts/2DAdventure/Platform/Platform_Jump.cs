using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Jump : Platform_Base
{
    [SerializeField]
    private float jumpForce = 23;
    [SerializeField]
    private float resetTime = 0.5f;

    private GameObject jumper;
    private Animator animator;

    public override void Setup()
    {
        animator = GetComponent<Animator>();
    }

    public override void UponCollision(GameObject player)
    {
        if ( hasCollided ) return;

        hasCollided = true;
        animator.SetTrigger("Bounce");

        jumper = player;
    }

    public void JumpAction()
    {
        jumper.GetComponent<MovementRigidbody2D>().Jump(jumpForce);
        jumper = null;

        Invoke(nameof(Reset), resetTime);
    }

    private void Reset()
    {
        hasCollided = false;
    }
}
