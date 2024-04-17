using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private PlayerStat playerStat;
    // Player HP
    [SerializeField]
    private Image[] playerHP = new Image[3];

    public void UpdateHP()
    {
        int lifeCount = playerStat.CurrentLife;

        for ( int i = 0; i < playerHP.Length; i++ )
        {
            playerHP[i].color = Color.white;
        }

        for ( int i = lifeCount; i < playerHP.Length; i++ )
        {
            playerHP[i].color = Color.black;
        }
    }

    public void UpdateCoin()
    {

    }

    public void UpdateProjectile()
    {

    }

    public void UpdateStars()
    {

    }
}
