using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class MovementEffects : MonoBehaviour
    {
        private MovementRigidbody2D movement;

        [SerializeField]
        private ParticleSystem footStepEffect;

        private ParticleSystem.EmissionModule emission;

        private void Awake()
        {
            movement = GetComponentInParent<MovementRigidbody2D>();
            emission = footStepEffect.emission;
        }

        private void Update()
        {
            // If player is on the ground and moving velocity isn't 0, that means the player is moving
            if ( movement.IsOnGround && movement.Velocity.x != 0 )
            {
                emission.rateOverTime = 30;
            }
            else
            {
                emission.rateOverTime = 0;
            }
        }
    }
}
