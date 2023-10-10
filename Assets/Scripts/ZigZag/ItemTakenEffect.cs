using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class ItemTakenEffect : MonoBehaviour
    {
        private ParticleSystem particle { get; set; }

        private void Init()
        {
            particle = GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
            // Play the Particle effect upon active
            if ( particle == null )
            {
                Init();
            }

            particle.Play();
        }

        private void Update()
        {
            if ( particle == null ) return;
            if (particle.isPlaying == false)
            {
                // After a play, gets deactivated
                gameObject.SetActive(false);
            }
        }
    }
}
