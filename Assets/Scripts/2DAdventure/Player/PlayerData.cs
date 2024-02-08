using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PlayerData : MonoBehaviour
    {
        private int coin;

        public int Coin
        {
            set => coin = Mathf.Clamp(coin, 0, 9999);
            get => coin;
        }
    }
}
