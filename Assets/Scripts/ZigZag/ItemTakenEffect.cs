using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTakenEffect : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();   
    }

    private void OnEnable()
    {
        // Play the Particle effect upon active
        particleSystem.Play();
    }

    private void Update()
    {
        if ( particleSystem.isPlaying == false )
        {
            // After a play, gets deactivated
            gameObject.SetActive(false);
        }
    }
}
