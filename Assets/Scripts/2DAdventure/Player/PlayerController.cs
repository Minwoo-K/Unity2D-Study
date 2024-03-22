using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementRigidbody2D movement;

    private void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
    }

    private void Update()
    {
        // Get the Input of the Horizontal in the InputManagaer (<- / ->)
        float xInput = Input.GetAxisRaw("Horizontal");
        // movingState is to polish the input to 3 different states: Idle/Walk/Run
        float movingState = 0.5f + Input.GetAxisRaw("Run") * 0.5f;
        
        // [xInput] 0: Idle / 0.5: Walk / 1: Run
        xInput *= movingState; 

        // Move the Player with the movement based on the xInput
        movement.MoveInX(xInput);
    }
}
