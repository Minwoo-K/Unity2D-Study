using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Base : MonoBehaviour
{
    [SerializeField]
    private bool isInstantDeath = false;

    public bool IsInstantDeath => isInstantDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isInstantDeath)
            {
                collision.gameObject.GetComponent<PlayerStatus>().PlayerDead();
            }
            else
            {
                collision.gameObject.GetComponent<PlayerStatus>().DecreaseHP();
            }
        }
    }
}
