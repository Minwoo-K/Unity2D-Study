using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBase : MonoBehaviour
{
    [SerializeField]
    protected bool isInstantDeath = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") == false ) return;

        if ( isInstantDeath )
        {
            Debug.Log("Player Dead");
        }
        else
        {
            collision.GetComponent<PlayerHP>().DecreaseHP();
        }
    }
}
