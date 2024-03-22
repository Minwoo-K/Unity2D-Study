using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementRigidbody2D movement;

    private void Update()
    {
        // [xInput] 0: Idle / 0.5: Walk / 1: Run
        float xInput = Input.GetAxisRaw("Horizontal");
        float movingState = 0.5f + Input.GetAxisRaw("Run") * 0.5f;

        xInput *= movingState; // 0: Idle / 0.5: Walk / 1: Run

        movement.MoveInX(xInput);
    }
}
