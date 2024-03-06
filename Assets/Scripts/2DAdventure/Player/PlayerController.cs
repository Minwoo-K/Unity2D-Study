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
        // x becomes 1 when rightArrow/D button is pressed, -1 when leftArrow/A button is pressed
        // Therefore, x eventually means a direction either left or right
        float x = Input.GetAxisRaw("Horizontal");
        // offset is to polish the input to distinguish manage different inputs(Idle, Walk, Run)
        float offset = 0.5f + Input.GetAxisRaw("Run") * 0.5f;
        // Put direction(x) and offset together
        x *= offset;

        // Update Movement
        UpdateMove(x);
        playerAnimator.UpdateAnimation(x);

        if ( x != 0 ) transform.localScale = new Vector3(( x > 0 ? 1 : -1), 1, 1);

        UpdateJump();
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
        else
        {
            movement.IsHigherJump = false;
        }
    }
}
