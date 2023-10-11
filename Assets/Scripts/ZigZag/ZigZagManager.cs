using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class ZigZagManager : MonoBehaviour
    {
        [Header("GameStart UI")]
        [SerializeField]
        private GameObject GameStartPanel;
        [SerializeField]
        private UITextFadeEffect[] UIFadeToStart;       // To execute fading effect upon the start of the game


        public bool gameStart { get; private set; } = false;
        public bool gameOver { get; private set; } = false;

        private IEnumerator Start()
        {
            for ( int i = 0; i < UIFadeToStart.Length; i++ )
            {
                UIFadeToStart[i].StartFading();
            }

            while ( true )
            {
                if ( Input.GetMouseButtonDown(0) )
                {
                    OnGameStart();

                    yield break;
                }

                yield return null;
            }
        }

        private void OnGameStart()
        {
            GameStartPanel.SetActive(false);

            gameStart = true;
        }
    }
}
