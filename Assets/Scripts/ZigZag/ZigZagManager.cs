using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZigZag
{
    public class ZigZagManager : MonoBehaviour
    {
        // private
        private int score;
        // public

        // SerializeField
        [Header("Game Start UI")]
        [SerializeField]
        private GameObject gameStartPanel;      // Game Start UI Panel
        [SerializeField]
        private UIFadeEffect[] fadeToStart;     // UI objects to fade at start
        
        [Header("In-Game UI")]
        [SerializeField]
        private TextMeshProUGUI scoreText;      // In-Game Score
        
        [Header("Game Over UI")]
        [SerializeField]
        private GameObject gameOverPanel;       // Game Over UI Panel
        [SerializeField]
        private TextMeshProUGUI endScore;       // The Score at the end of a game
        [SerializeField]
        private TextMeshProUGUI bestScore;      // The Best Score
        [SerializeField]
        private float slowTime;                 // Time to be slow

        // public property
        public bool GameStart { get; private set; } = false;
        public bool GameOver { get; private set; } = false;

        private IEnumerator Start()
        {
            Time.timeScale = 1;
            score = 0;

            for (int i = 0; i < fadeToStart.Length; i++)
            {
                fadeToStart[i].StartFading();
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
            GameStart = true;

            gameStartPanel.SetActive(false);

            scoreText.gameObject.SetActive(true);
        }

        private IEnumerator SlowAndStop()
        {
            float current = 0;
            float percent = 0;

            // Slow the game for the given time
            while ( percent < 1 )
            {
                current += Time.deltaTime;
                percent = current / slowTime;

                Time.timeScale = 0.5f;

                yield return null;
            }

            // Stop the timeScale
            Time.timeScale = 0;
        }

        // Update the score and Best Score upon GameOver
        private void UpdateScore()
        {
            int best = PlayerPrefs.GetInt("BestScore");
            
            best = best >= score ? best : score;

            endScore.text = score.ToString();

            bestScore.text = best.ToString();
        }

        // Behaviours upon GameOver
        public void OnGameOver()
        {
            GameOver = true;

            gameOverPanel.SetActive(true);

            scoreText.gameObject.SetActive(false);

            UpdateScore();

            StartCoroutine(SlowAndStop());
        }

        public void OnRestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void IncreaseScore()
        {
            score++;

            scoreText.text = score.ToString();
        }
    }
}
