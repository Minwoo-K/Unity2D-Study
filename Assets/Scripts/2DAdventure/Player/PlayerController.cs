using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode;

    private MovementRigidbody2D movement;

    private void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
    }

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float offsetX = 0.5f + Input.GetAxisRaw("Run") * 0.5f;
        
        inputX *= offsetX;

        UpdateMove(inputX);
    }

    private void UpdateMove(float inputX)
    {
        movement.MoveTo(inputX);
    }
}
