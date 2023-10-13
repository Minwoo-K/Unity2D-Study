using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        private TextMeshProUGUI finalScore;
        [SerializeField]
        private TextMeshProUGUI bestScore;
        
        [SerializeField]
        private float delayTime;

        private int score;
        private Dictionary<int, Data.ZigZagDatum> ZigZagLevelData = null;

        public bool IsGameStart { get; private set; } = false;
        public bool IsGameOver { get; private set; } = false;

        private IEnumerator Start()
        {
            score = 0;
            Time.timeScale = 1;
            ZigZagLevelData = DataManager.Data.ZigZag;

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

        // Update the Final Score and Best Score upon GameOver
        private void UpdateScoreBoard()
        {
            //Update the Final Score
            finalScore.text = score.ToString();
            // Retrieve the Best Score from PlayerPrefs
            int best = PlayerPrefs.GetInt("BestScore");
            // Get the Best score from between the current score and the previous best score
            best = best > score ? best : score;
            // Save the best score on PlayerPrefs
            PlayerPrefs.SetInt("BestScore", best);
            // Update the best score on the score board
            bestScore.text = best.ToString();
        }

        public void GameOver()
        {
            // IsGameOver flag on
            IsGameOver = true;
            // Turn off the in-Game panel
            inGamePanel.SetActive(false);
            // Show game over panel
            gameOverPanel.SetActive(true);
            // Update the final score board
            UpdateScoreBoard();
            // For the Player to fall and stop the timeScale
            StartCoroutine(FallingAndStop());
        }

        public void IncreaseScore(int point)
        {
            score += point;

            scoreText.text = score.ToString();
        }

        public void OnRestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
