using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;

    private MovementRigidbody2D movement;
    private PlayerAnimator playerAnimator;

    private void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    private void Update()
    {
        // Getting the 'x' is the core of how the Player object moves
        // Will get 1 if 'd' or rightArrow is pressed, -1 if 'a' or leftArrow is pressed
        float x     = Input.GetAxisRaw("Horizontal");
        // If "Run" button isn't on, the value in the brackets is 0
        float runningParameter = 0.5f + (Input.GetAxisRaw("Run") * 0.5f);
        x = x * runningParameter;

        UpdateMove(x);
        UpdateJump();
        playerAnimator.UpdateAnimation(x);
    }

    private void UpdateMove(float x)
    {
        movement.MoveTo(x);
    }

    private void UpdateJump()
    {
        if ( Input.GetKeyDown(jumpKeyCode) )
        {
            movement.Jump();
        }
        
        if ( Input.GetKey(jumpKeyCode) )
        {
            movement.IsHigherJump = true;
        }
        else if ( Input.GetKeyUp(jumpKeyCode) )
        {
            movement.IsHigherJump = false;
        }
    }
}
