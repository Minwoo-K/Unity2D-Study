using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;

    private MovementRigidbody2D movement;

    private void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
    }

    private void Update()
    {
        float x     = Input.GetAxisRaw("Horizontal");
        Debug.Log($"Input.GetAxisRaw(Run): {x}");
        // If "Run" button isn't on, the value in the brackets is 0
        float runningParameter = 0.5f + (Input.GetAxisRaw("Run") * 0.5f);

        x = x * runningParameter;

        UpdateMove(x);
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
        else if ( Input.GetKeyUp(jumpKeyCode) )
        {
            movement.IsHigherJump = false;
        }
    }
}
