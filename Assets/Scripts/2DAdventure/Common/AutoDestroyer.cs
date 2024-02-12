using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class AutoDestroyer : MonoBehaviour
    {
        [SerializeField]
        private bool deactivate;
        [SerializeField]
        private float lastingTime = 5;

        private IEnumerator Start()
        {
            while ( lastingTime > 0 )
            {
                lastingTime -= Time.deltaTime;

                yield return null;
            }

            if ( deactivate )
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

