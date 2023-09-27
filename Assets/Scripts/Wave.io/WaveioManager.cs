using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Waveio
{
    public class WaveioManager : MonoBehaviour
    {
        [Header("UI Control Section")]
        [SerializeField]
        private TextMeshProUGUI textTitle;
        [SerializeField]
        private TextMeshProUGUI textTapToPlay;
        [SerializeField]
        private TextMeshProUGUI textScore;
        [SerializeField]
        private TextMeshProUGUI textCurrentScore;
        [SerializeField]
        private TextMeshProUGUI textBestScore;
        [SerializeField]
        private GameObject continueButton;
        [SerializeField]
        private CameraController cameraController;

        private int score = 0;
        private float gameDelayTime = 1f;

        public bool gameOver { get; private set; } = false;


        private IEnumerator Start()
        {
            int bestScore = PlayerPrefs.GetInt("BestScore");
            textBestScore.text = $"<size=50>BEST SCORE\n<size=70>{bestScore}";

            while (true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    StartGame();

                    yield break;
                }

                yield return null;
            }
        }

        private void Update()
        {

        }

        private void StartGame()
        {
            textTitle.gameObject.SetActive(false);
            textTapToPlay.gameObject.SetActive(false);
            textCurrentScore.gameObject.SetActive(true);
        }

        public void GameOver()
        {
            gameOver = true;

            StartCoroutine(OnGameOver());
        }

        private IEnumerator OnGameOver()
        {
            yield return new WaitForSeconds(gameDelayTime);

            continueButton.SetActive(true);
            textScore.gameObject.SetActive(true);

            int bestScore = PlayerPrefs.GetInt("BestScore");

            if (score > bestScore)
            {
                PlayerPrefs.SetInt("BestScore", score);

                //textBestScore.gameObject.SetActive(true);
                textBestScore.text = $"<size=50>BEST SCORE\n<size=70>{score}";
            }
        }

        public void OnContinueButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ScoreIncreased()
        {
            score++;

            textCurrentScore.text = score.ToString();

            cameraController.ChangeBackgroundColour();
        }
    }
}
