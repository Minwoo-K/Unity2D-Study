using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Adventure_2D;
public class EnemyProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            collision.gameObject.GetComponent<PlayerHP>().DecreaseHP();
            Destroy(gameObject);
        }
    }
}
