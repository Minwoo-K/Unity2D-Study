using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode runKeyCode;
    [SerializeField]
    private KeyCode jumpKeyCode;

    private RigidbodyMovement2D movement;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        movement = GetComponent<RigidbodyMovement2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");

        UpdateSpriteFlipX(xInput);

        float offset = 0.5f + (Input.GetAxis("Run") * 0.5f);

        xInput *= offset;
        
        movement.Move(xInput);
    }

    private void UpdateSpriteFlipX(float x)
    {
        if (x == 0) return;

        spriteRenderer.flipX = x == 1 ? false : true;
    }
}
