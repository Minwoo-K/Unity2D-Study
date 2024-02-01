using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class MovementEffects : MonoBehaviour
    {
        private MovementRigidbody2D movement;

        // Player's foot step effect when walking/running
        [SerializeField]
        private ParticleSystem footStepEffect;
        private ParticleSystem.EmissionModule emission;

        // Player's landing effect when landing from a jump/drop
        [SerializeField]
        private ParticleSystem landingEffect;
        private bool wasOnGround;

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

            // If currently on the ground but, WAS on ground a frame before, and player's velocity has become less than 0,
            // that means the player lands on this frame, which plays the Landing Effect
            if ( !wasOnGround && movement.IsOnGround && movement.Velocity.y <= 0 )
            {
                landingEffect.Stop(); // To avoid playing the effect again and again from repetitive lands
                landingEffect.Play();
            }

            // Store the status of player this frame to compare the next frame
            wasOnGround = movement.IsOnGround;
        }
    }
}
