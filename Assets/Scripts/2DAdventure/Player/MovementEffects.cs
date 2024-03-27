using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem footStepEffect;
    [SerializeField]
    private GameObject landingEffect;

    private ParticleSystem.EmissionModule emission;
    private RigidMovement2D movement;
    private bool WasOnGround { get; set; }

    private void Awake()
    {
        movement = GetComponentInParent<RigidMovement2D>();
        emission = footStepEffect.emission;
    }

    private void Update()
    {
        if ( ! WasOnGround && movement.IsOnGround )
        {
            Instantiate(landingEffect, transform.position, Quaternion.identity);
        }

        if ( movement.IsOnGround && movement.Velocity.x != 0 )
        {
            emission.rateOverTime = 30;
        }
        else
        {
            emission.rateOverTime = 0;
        }

        WasOnGround = movement.IsOnGround;
    }
}
