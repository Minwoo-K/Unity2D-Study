using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class ObstacleBase : MonoBehaviour
    {
        [SerializeField]
        protected bool isInstantDeath = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") == false) return;

            if (isInstantDeath)
            {
                collision.GetComponent<PlayerController>().OnDie();
            }
            else
            {
                collision.GetComponent<PlayerHP>().DecreaseHP();
            }
        }
    }
}
