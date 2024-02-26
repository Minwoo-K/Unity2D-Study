using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private UI_PopupController ui_Controller;
        [SerializeField]
        private PlayerData playerData;

        private int currentLevel = 1;
        private bool isLevelComplete = false;
        private bool isLevelFailed = false;

        public void OnDie()
        {
            if ( isLevelFailed ) return;

            isLevelFailed = true;

            ui_Controller.LevelFailed();
        }

        public void LevelComplete()
        {
            if ( isLevelComplete ) return;

            isLevelComplete = true;

            ui_Controller.LevelComplete(playerData.StarsEarned);
            Define.SaveUponLevelComplete(currentLevel, playerData.StarsEarned, playerData.Coin);
        }
    }
}

