using UnityEngine;

namespace Adventure_2D
{
    public class ParticleAutoDestroyer : MonoBehaviour
    {
        private ParticleSystem theParticle;

        private void Awake()
        {
            theParticle = GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            if (!theParticle.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
