using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    [SerializeField]
    private GameObject movementEffect;

    private ParticleSystem movementParticle;
    private ParticleSystem.EmissionModule emission;

    [SerializeField]
    private GameObject landingEffect;

    private MovementRigid2D movement;

    private bool wasOnGround = false;

    private void Awake()
    {
        movement = GetComponent<MovementRigid2D>();
        movementParticle = movementEffect.GetComponentInChildren<ParticleSystem>();
        emission = movementParticle.emission;
    }

    private void Update()
    {
        if ( !wasOnGround && movement.IsOnGround ) 
            Instantiate(landingEffect, movement.FeetPosition, Quaternion.identity);

        if ( movement.Velocity.x != 0 && movement.IsOnGround )
        {
            emission.rateOverTime = 30;
        }
        else
        {
            emission.rateOverTime = 0;
        }

        wasOnGround = movement.IsOnGround;
    }
}
