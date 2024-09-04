using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    [SerializeField]
    private GameObject movementEffect;
    private ParticleSystem.EmissionModule emission;

    private MovementRigidbody2D movement;

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
    }
}
