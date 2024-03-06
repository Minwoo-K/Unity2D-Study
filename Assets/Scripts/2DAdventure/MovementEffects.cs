using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    private MovementRigidbody2D movement;

    [SerializeField]
    private ParticleSystem footStepEffect;
    private ParticleSystem.EmissionModule footStepEmission;
    
    [SerializeField]
    private ParticleSystem landingEffect;
    private bool WasOnGround { get; set; } = false;


    private void Awake()
    {
        movement = GetComponentInParent<MovementRigidbody2D>();
        footStepEmission = footStepEffect.emission;
    }

    private void Update()
    {
        if ( movement.IsOnGround && movement.Velocity.x != 0 )
        {
            footStepEmission.rateOverTime = 30;
        }
        else
        {
            footStepEmission.rateOverTime = 0;
        }

        if ( movement.IsOnGround && !WasOnGround && movement.Velocity.y < 0 )
        {
            landingEffect.Stop();
            landingEffect.Play();
        }

        WasOnGround = movement.IsOnGround;
    }
}
