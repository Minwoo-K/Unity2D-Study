using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;

    MovementRigid2D movementRigid2D;

    private void Awake()
    {
        movementRigid2D = GetComponent<MovementRigid2D>();
    }

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float offsetX = Input.GetAxisRaw("Run") * 0.5f;
        inputX = inputX * 0.5f + offsetX;
        
        UpdateMove(inputX);
        UpdateJump();
    }

    private void UpdateMove(float x)
    {
        movementRigid2D.MoveTo(x);
    }

    private void UpdateJump()
    {
        if ( Input.GetKeyDown(jumpKeyCode) )
        {
            movementRigid2D.Jump();
        }
        else if ( Input.GetKey(jumpKeyCode) )
        {
            movementRigid2D.IsHigherJump = true;
        }
        else
        {
            movementRigid2D.IsHigherJump = false;
        }
    }
}
