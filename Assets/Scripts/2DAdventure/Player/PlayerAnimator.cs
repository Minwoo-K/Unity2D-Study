using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private MovementRigidbody2D movement;
    private Animator playerAnimator;

    private void Awake()
    {
        movement        = GetComponentInParent<MovementRigidbody2D>();
        playerAnimator  = GetComponent<Animator>();
    }

    public void UpdateAnimation(float x)
    {
        if ( x != 0 )
        {
            movement.transform.localScale = new Vector3((x > 0 ? 1 : -1), 1, 1);
        }

        playerAnimator.SetBool("isJumping", !movement.IsOnGround);

        if ( movement.IsOnGround )
        {
            playerAnimator.SetFloat("velocityX", Mathf.Abs(x));
        }
        else
        {
            Debug.Log($"movement.Velocity.y? {movement.Velocity.y}");
            playerAnimator.SetFloat("velocityY", movement.Velocity.y);
        }
    }
}
