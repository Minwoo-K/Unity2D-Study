using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Jump : Platform_Base
{
    [SerializeField]
    private float jumpForce;

    private Animator animator;
    private GameObject player;
    private float coolTime = 0.5f;

    public bool IsHit { get; private set; } = false;

    public override void Setup()
    {
        animator = GetComponent<Animator>();
    }

    public override void UponCollision(GameObject player)
    {
        if ( IsHit ) return;

        IsHit = true;
        this.player = player;
        animator.SetTrigger("JumpTrigger");
    }

    public void JumpAction()
    {
        if ( player == null ) return;

        player.GetComponent<RigidMovement2D>().Jump(jumpForce);
        player = null;

        Invoke(nameof(Reset), coolTime);
    }

    private void Reset()
    {
        IsHit = false;
    }
}
