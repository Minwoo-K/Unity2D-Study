using UnityEngine;

public class ParticleAutoDestroyer : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem theParticle;

    private void Awake()
    {
        theParticle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if ( !theParticle.isPlaying )
        {
            Destroy(gameObject);
        }
    }
}
