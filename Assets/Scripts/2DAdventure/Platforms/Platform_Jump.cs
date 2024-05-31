using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Jump : Platform_Base
{
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float cooldown = 1f;

    private bool isTriggered = false;
    private Animator animator;
    private GameObject player;

    public override void Setup()
    {
        animator = GetComponent<Animator>();
    }

    public override void UpdateCollision(Transform player)
    {
        if ( isTriggered ) return;

        isTriggered = true;

        if ( player.CompareTag("Player") )
        {
            this.player = player.gameObject;
            animator.SetTrigger("JumpTrigger");
            Invoke("Reset", cooldown);
        }
    }

    public void JumpAction()
    {
        if (player == null) return;

        player.GetComponent<RigidbodyMovement2D>().Jump(jumpForce);
    }

    private void Reset()
    {
        isTriggered = false;
        player = null;
    }
}
