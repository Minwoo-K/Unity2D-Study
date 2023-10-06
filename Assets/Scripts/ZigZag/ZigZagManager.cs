using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZigZag
{
    public class ZigZagManager : MonoBehaviour
    {
        // private
        // public
        // SerializeField
        // public property
        [Header("Game Start UI")]
        [SerializeField]
        private GameObject gameStartPanel;      // Game Start UI Panel
        [SerializeField]
        private UIFadeEffect[] fadeToStart;     // UI objects to fade at start
        [Header("Game Over UI")]
        [SerializeField]
        private GameObject gameOverPanel;       // Game Over UI Panel
        [SerializeField]
        private float slowTime;                 // Time to be slow

        public bool GameStart { get; private set; } = false;
        public bool GameOver { get; private set; } = false;

        private IEnumerator Start()
        {
            Time.timeScale = 1;

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
        }

        public void OnGameOver()
        {
            GameOver = true;

            gameOverPanel.SetActive(true);

            StartCoroutine(SlowAndStop());
        }

        public void OnRestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    }
}
