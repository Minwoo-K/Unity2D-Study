using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Thorn : Obstacle_Base
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            if ( instantKill )
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
