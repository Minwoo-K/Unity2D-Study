using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [SerializeField, Tooltip("Must be 3 at all times")]
    private Image[] hps;
    [SerializeField]
    private TextMeshProUGUI coinCountUI;
    [SerializeField]
    private TextMeshProUGUI projectileCountUI;

    private int coin = 0;

    public void UpdateHP(int count)
    {
        // To Fill
        for ( int i = count - 1; i >= 0; i-- )
        {
            hps[i].color = Color.white;
        }

        // To Empty
        for (int i = count; i < hps.Length; i++ )
        {
            hps[i].color = Color.black;
        }
    }

    public void UpdateCoin()
    {
        coin++;
        coinCountUI.text = $"x {coin}";
    }

    public void UpdateProjectile(int count)
    {
        projectileCountUI.text = $"{count}/9"; // Projectile Count Max is 9
    }

    public void UpdateStar()
    {

    }
}
