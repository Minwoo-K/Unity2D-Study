using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PlayerData : MonoBehaviour
    {
        [SerializeField]
        private UI_PlayerData ui_PlayerData;

        private int coin;
        private int projectile;
        private bool[] stars = new bool[3] { false, false, false };

        public int Coin
        {
            set
            {
                coin = Mathf.Clamp(value, 0, 9999);
                ui_PlayerData.SetCoin(coin);
            }
            get => coin;
        }
        public int MaxProjectile { get; }   = 10;
        public int CurrentProjectile
        {
            set
            {
                projectile = Mathf.Clamp(value, 0, MaxProjectile);
                ui_PlayerData.SetProjectile(projectile, MaxProjectile);
            }
            get => projectile;
        }
        public bool[] StarsEarned => stars;

        private void Awake()
        {
            CurrentProjectile = 0;
        }

        public void GetStar(int index)
        {
            stars[index] = true;
            ui_PlayerData.GetStar(index);
        }

    }
}
