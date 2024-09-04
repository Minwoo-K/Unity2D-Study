using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    // Movement Effect
    [SerializeField]
    private GameObject movementEffect;
    private ParticleSystem.EmissionModule emission;

    // Landing Effect
    [SerializeField]
    private GameObject landingEffect;

    // Private Variables
    private MovementRigidbody2D movement;
    private bool wasOnGround = false;

    private void Awake()
    {
        emission = GetComponentInChildren<ParticleSystem>().emission;

        movement = GetComponent<MovementRigidbody2D>();
    }

    private void Update()
    {
        // Movement Effect
        if ( movement.Velocity.x != 0 && movement.IsOnGround )
        {
            emission.rateOverTime = 30;
        }
        else
        {
            emission.rateOverTime = 0;
        }

        if ( movement.IsOnGround && !wasOnGround )
        {
            Instantiate(landingEffect, transform.position, Quaternion.identity);
        }

        wasOnGround = movement.IsOnGround;
    }
}
