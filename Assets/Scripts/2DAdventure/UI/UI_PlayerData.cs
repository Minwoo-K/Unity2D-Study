using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Adventure_2D
{
    public class UI_PlayerData : MonoBehaviour
    {
        [Header("HP")]
        [SerializeField]
        private Image[] hpImages;

        [Header("Coin")]
        [SerializeField]
        private TextMeshProUGUI coin_text; 

        public void SetHP(int index, bool isActive)
        {
            hpImages[index].color = isActive == true ? Color.white : Color.black;
        }

        public void SetCoin(int coin)
        {
            coin_text.text = $"x {coin}";
        }
    }
}


