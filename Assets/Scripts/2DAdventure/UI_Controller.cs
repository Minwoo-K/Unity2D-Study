using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [SerializeField]
    private PlayerStatus playerStatus;
    [SerializeField, Tooltip("Must be 3 at all times")]
    private Image[] hps;
    [SerializeField]
    private TextMeshProUGUI coinCountUI;
    [SerializeField]
    private TextMeshProUGUI projectileCountUI;
    [SerializeField, Tooltip("Must be 3 at all times")]
    private GameObject[] starUI;

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
        coinCountUI.text = $"x {playerStatus.Coin}";
    }

    public void UpdateProjectile(int count)
    {
        projectileCountUI.text = $"{count}/9"; // Projectile Count Max is 9
    }

    public void UpdateStar()
    {
        bool[] stars = playerStatus.Stars;

        for ( int i = 0; i < stars.Length; i++ )
        {
            starUI[i].SetActive(stars[i]);
        }
    }
}
