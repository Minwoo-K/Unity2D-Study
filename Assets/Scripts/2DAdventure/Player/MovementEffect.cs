using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffect : MonoBehaviour
{
    // Moving Effect
    [SerializeField]
    private ParticleSystem movingEffect;
    private ParticleSystem.EmissionModule emission;

    // LandingEffect
    [SerializeField]
    private GameObject landingEffectPrefab;

    // Necessary Variables
    private RigidbodyMovement2D movement;
    private bool wasOnGround = true;

    private void Awake()
    {
        emission = movingEffect.emission;
        movement = GetComponent<RigidbodyMovement2D>();
    }

    private void Update()
    {
        if ( Mathf.Abs(movement.Velocity.x) > 0 && movement.IsOnGround ) 
            emission.rateOverTime = 30;
        else
            emission.rateOverTime = 0;

        if ( !wasOnGround && movement.IsOnGround )
        {
            Instantiate(landingEffectPrefab, transform.position, Quaternion.identity);
        }

        wasOnGround = movement.IsOnGround;
    }
}
