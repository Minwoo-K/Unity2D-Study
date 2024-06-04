using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private int hp;
    private int coin;

    public int HP   => hp;
    public int Coin => coin;

    public void DecreaseHP()
    {
        if ( hp > 0 ) hp--;

        if ( hp == 0 ) PlayerDead();
    }

    public void EarnCoin()
    {
        coin++;
    }

    public void PlayerDead()
    {
        Debug.Log("Game Over");
    }
}
