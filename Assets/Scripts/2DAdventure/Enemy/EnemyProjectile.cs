using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            collision.GetComponent<PlayerStat>().DecreaseLife();
            Destroy(gameObject);
        }
    }
}
