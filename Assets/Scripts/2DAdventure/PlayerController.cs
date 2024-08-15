using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // SerializeField
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;

    private MovementRigid2D movement;

    private void Awake()
    {
        movement = GetComponent<MovementRigid2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float offset = 0.5f + Input.GetAxisRaw("Run") * 0.5f;
        x *= offset;

        UpdateMove(x);
        UpdateJump();
    }

    private void UpdateMove(float input)
    {
        movement.MoveTo(input);
    }

    private void UpdateJump()
    {
        if ( Input.GetKeyDown(jumpKeyCode) )
        {
            movement.Jump();
        }
        else if ( Input.GetKey(jumpKeyCode) )
        {
            movement.IsLongJump = true;
        }
        else if ( Input.GetKeyUp(jumpKeyCode) )
        {
            movement.IsLongJump = false;
        }
    }
}
