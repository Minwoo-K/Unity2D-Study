using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private UI_PopupController ui_Controller;

        private bool isLevelFailed = false;

        public void OnDie()
        {
            if ( isLevelFailed ) return;

            isLevelFailed = true;

            ui_Controller.LevelFailed();
        }
    }
}

