using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Base : MonoBehaviour
{
    public bool IsDead { get; protected set; } = false;

    public abstract void OnDead();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStat>().DecreaseLife();
        }

        if (collision.CompareTag("PlayerProjectile"))
        {
            Destroy(collision.gameObject);
            OnDead();
        }
    }
}
