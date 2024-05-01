using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;

    private ParticleSystem.EmissionModule emission;
    private RigidbodyMovement2D movement;

    private void Awake()
    {
        emission = particle.emission;
        movement = GetComponent<RigidbodyMovement2D>();
    }

    private void Update()
    {
        if ( Mathf.Abs(movement.Velocity.x) > 0 && movement.IsOnGround ) 
            emission.rateOverTime = 30;
        else
            emission.rateOverTime = 0;
    }
}
