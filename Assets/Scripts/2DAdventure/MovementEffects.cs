using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem footStepEffect;
    private ParticleSystem.EmissionModule footStepEmission;

    [SerializeField]
    private ParticleSystem landingEffect;
    private bool wasOnGround = false;

    private MovementRigidbody2D movement;

    private void Awake()
    {
        footStepEmission = footStepEffect.emission;
        movement = GetComponentInParent<MovementRigidbody2D>();
    }

    private void Update()
    {
        // if moving on the ground
        if ( movement.Velocity.x != 0 && movement.IsOnGround )
        {
            footStepEmission.rateOverTime = 30;
        }
        else
        {
            footStepEmission.rateOverTime = 0;
        }

        // if the player has landed on the previous frame
        if ( movement.IsOnGround && !wasOnGround )
        {
            landingEffect.Stop();
            landingEffect.Play();
        }

        wasOnGround = movement.IsOnGround;
    }
}
