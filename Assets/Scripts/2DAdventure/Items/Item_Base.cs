using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Base : MonoBehaviour
{
    public abstract void UpdateCollision(GameObject player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            UpdateCollision(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
