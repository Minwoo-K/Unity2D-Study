using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Adventure_2D
{
    public class UI_PlayerData : MonoBehaviour
    {
        [SerializeField]
        private Image[] hpImages;

        public void SetHP(int index, bool isActive)
        {
            hpImages[index].color = isActive == true ? Color.white : Color.black;
        }
    }
}


