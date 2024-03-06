using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem footStepEffect;

    private MovementRigidbody2D movement;
    private ParticleSystem.EmissionModule footStepEmission;

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
    }
}
