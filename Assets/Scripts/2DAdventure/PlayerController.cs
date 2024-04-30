using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private RigidbodyMovement2D movement;
    

    private void Awake()
    {
        movement = GetComponent<RigidbodyMovement2D>();
    }

    private void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        Debug.Log(xInput);
        movement.Move(xInput);
    }
}
