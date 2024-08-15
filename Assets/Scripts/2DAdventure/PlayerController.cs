using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

        MoveTo(x);
    }

    private void MoveTo(float input)
    {
        movement.MoveTo(input);
    }
}
