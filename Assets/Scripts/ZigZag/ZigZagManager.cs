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

        [Header("GameOver UI")]
        [SerializeField]
        private GameObject GameOverPanel;
        [SerializeField]
        private float delayTime;

        public bool gameStart { get; private set; } = false;
        public bool gameOver { get; private set; } = false;

        private IEnumerator Start()
        {
            Time.timeScale = 1;

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

        public void GameOver()
        {
            gameOver = true;

            GameOverPanel.SetActive(true);

            StartCoroutine(FallingAndStop());
        }

        private IEnumerator FallingAndStop()
        {
            float current = 0;
            float percent = 0;

            while ( percent < 1 )
            {
                current += Time.deltaTime;
                percent = current / delayTime;

                Time.timeScale = 0.5f;

                yield return null;
            }

            Time.timeScale = 0f;
        }
    }
}
