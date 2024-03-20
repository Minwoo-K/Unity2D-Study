using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Jump : Platform_Base
{
    private Animator animator;
    private GameObject player;
    private float jumpForce = 22;
    private float coolTime = 1f;

    public override void SetUp()
    {
        animator = GetComponent<Animator>();
    }

    public override void UponCollision(GameObject player)
    {
        if ( hasCollided ) return;

        hasCollided = true;

        this.player = player;
        animator.SetTrigger("Bounce");

        Invoke(nameof(Reset), coolTime);
    }

    public void JumpAction()
    {
        if ( player != null )
        {
            player.GetComponent<MovementRigidbody2D>().Jump(jumpForce);
        }
    }

    private void Reset()
    {
        player = null;
        hasCollided = false;
    }
}
