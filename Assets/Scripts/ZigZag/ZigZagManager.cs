using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ZigZag
{
    public class ZigZagManager : MonoBehaviour
    {
        [Header("GameStart UI")]
        [SerializeField]
        private GameObject gameStartPanel;
        [SerializeField]
        private UITextFadeEffect[] UIFadeToStart;       // To execute fading effect upon the start of the game

        [Header("In Game UI")]
        [SerializeField]
        private GameObject inGamePanel;
        [SerializeField]
        private TextMeshProUGUI scoreText;

        [Header("GameOver UI")]
        [SerializeField]
        private GameObject gameOverPanel;
        [SerializeField]
        private float delayTime;

        private int score;

        public bool IsGameStart { get; private set; } = false;
        public bool IsGameOver { get; private set; } = false;

        private IEnumerator Start()
        {
            score = 0;
            Time.timeScale = 1;

            for ( int i = 0; i < UIFadeToStart.Length; i++ )
            {
                UIFadeToStart[i].StartFading();
            }

            while ( true )
            {
                if ( Input.GetMouseButtonDown(0) )
                {
                    GameStart();

                    yield break;
                }

                yield return null;
            }
        }

        private void GameStart()
        {
            gameStartPanel.SetActive(false);

            inGamePanel.SetActive(true);

            IsGameStart = true;
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

        public void GameOver()
        {
            IsGameOver = true;

            inGamePanel.SetActive(false);

            gameOverPanel.SetActive(true);

            StartCoroutine(FallingAndStop());
        }

        public void IncreaseScore(int point)
        {
            score += point;

            scoreText.text = score.ToString();
        }

    }
}
