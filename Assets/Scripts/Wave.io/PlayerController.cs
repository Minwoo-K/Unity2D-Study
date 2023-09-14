using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;  // Player Movement script

    void Start()
    {
        // Fetch the component
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Mathematic calculation should be in FixedUpdate
    void FixedUpdate()
    {
        // Player always moves within the X axis
        playerMovement.MoveInX();
        
        // Moves up only when the left mouse button is being held down
        if ( Input.GetMouseButton(0) )
        {
            playerMovement.MoveUpY();
        }
    }
}
