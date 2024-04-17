using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private PlayerStat playerStat;
    // Player HP
    [SerializeField]
    private Image[] playerHP = new Image[3];
    // Coin
    [SerializeField]
    private TextMeshProUGUI coinCount;

    private void Awake()
    {
        UpdateCoin();
    }

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
        coinCount.text = $"x {playerStat.Coin}";
    }

    public void UpdateProjectile()
    {

    }

    public void UpdateStars()
    {

    }
}
