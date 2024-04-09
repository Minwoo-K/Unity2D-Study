using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Base : MonoBehaviour
{
    [SerializeField]
    protected bool instantKill;

    private void Awake()
    {
        Setup();
    }

    public virtual void Setup()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (instantKill)
            {
                collision.GetComponent<PlayerStat>().PlayerDead();
            }
            else
            {
                collision.GetComponent<PlayerStat>().DecreaseLife();
            }
        }
    }
}
