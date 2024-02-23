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

        [Header("COIN")]
        [SerializeField]
        private TextMeshProUGUI coin_text; 

        [Header("PROJECTILE")]
        [SerializeField]
        private TextMeshProUGUI projectile_text;

        [Header("STARS")]
        [SerializeField]
        private GameObject[] starObjects;

        public void SetHP(int index, bool isActive)
        {
            hpImages[index].color = isActive == true ? Color.white : Color.black;
        }

        public void SetCoin(int coin)
        {
            coin_text.text = $"x {coin}";
        }

        public void SetProjectile(int currentNumber, int maxNumber)
        {
            if ( (float)currentNumber / maxNumber <= 0.3f )
            {
                projectile_text.color = Color.red;
            }
            else
            {
                projectile_text.color = Color.white;
            }

            projectile_text.text = $"{currentNumber} / {maxNumber}";
        }

        public void GetStar(int index)
        {
            starObjects[index].SetActive(true);
        }
    }
}


