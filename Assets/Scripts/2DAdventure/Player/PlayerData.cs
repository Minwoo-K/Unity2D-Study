using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PlayerData : MonoBehaviour
    {
        private int coin;
        private int projectile = 0;

        public int Coin
        {
            set => coin = Mathf.Clamp(coin, 0, 9999);
            get => coin;
        }

        public int MaxProjectile { get; }   = 10;
        public int CurrentProjectile
        {
            set => projectile = Mathf.Clamp(value, 0, MaxProjectile);
            get => projectile;
        }
    }
}
