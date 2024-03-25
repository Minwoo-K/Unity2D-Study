using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKey;

    private RigidMovement2D movement;

    private void Awake()
    {
        movement = GetComponent<RigidMovement2D>();
    }

    private void Update()
    {
        // Input from Left/Right Arrows (value returned: -1 / +1)
        float xInput = Input.GetAxisRaw("Horizontal");
        // Input from the Run key registered in the ProjectSettings (value returned: 0 / +1)
        float runInput = Input.GetAxisRaw("Run");
        // To polish the input and make it a state, Walk/Run 
        float offset = 0.5f + runInput*0.5f;
        // To make the input be defined to a state
        xInput *= offset;
        // Command movement according to the input
        movement.Move(xInput);
    }
}
