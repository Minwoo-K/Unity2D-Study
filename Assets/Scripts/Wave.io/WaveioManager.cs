using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Waveio
{
    public class WaveioManager : MonoBehaviour
    {
        [Header("Core Objects")]
        [SerializeField]
        private PlayerController playerController;
        [SerializeField]
        private CameraController cameraController;
        [SerializeField]
        private AreaSpawner areaSpawner;
        [SerializeField]
        private int currentLevel = 1;
        [SerializeField]
        private AudioClip scoreSound;
        [SerializeField]
        private AudioClip crashSound;

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
        private TextMeshProUGUI textLevel;
        [SerializeField]
        private GameObject continueButton;

        private int score = 0;
        private float gameDelayTime = 1f;
        private AudioSource audioSource;
        private Dictionary<int, Data.WaveioDatum> WaveioLevelData = null;

        public bool gameStart { get; private set; } = false;
        public bool gameOver { get; private set; } = false;


        private void Start()
        {
            if (WaveioLevelData == null)
            {
                WaveioLevelData = new Dictionary<int, Data.WaveioDatum>();
                WaveioLevelData = DataManager.Data.Waveio;
            }

            int bestScore = PlayerPrefs.GetInt("BestScore");
            textBestScore.text = $"<size=50>BEST SCORE\n<size=70>{bestScore}";

            audioSource = GetComponent<AudioSource>();

            StartCoroutine(StartGame());
        }

        private IEnumerator StartGame()
        {
            while ( gameStart == false )
            {
                if ( Input.GetMouseButtonDown(0) )
                {
                    gameStart = true;
                }

                yield return null;
            }

            textTitle.gameObject.SetActive(false);
            textTapToPlay.gameObject.SetActive(false);
            textCurrentScore.gameObject.SetActive(true);
            textLevel.gameObject.SetActive(true);
        }

        public void GameOver()
        {
            gameOver = true;
            audioSource.PlayOneShot(crashSound);

            StartCoroutine(OnGameOver());
        }

        private IEnumerator OnGameOver()
        {
            yield return new WaitForSeconds(gameDelayTime);

            continueButton.SetActive(true);
            textScore.gameObject.SetActive(true);
            textBestScore.gameObject.SetActive(true);

            int bestScore = PlayerPrefs.GetInt("BestScore");

            if (score > bestScore)
            {
                PlayerPrefs.SetInt("BestScore", score);

                //textBestScore.gameObject.SetActive(true);
                textBestScore.text = $"<size=50>BEST SCORE\n<size=70>{score}";
            }

            textBestScore.gameObject.SetActive(true);
        }

        public void OnContinueButton()
        {
            ResetTo(1);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void LevelIncreased()
        {
            currentLevel++;

            playerController.SetLevelTo(WaveioLevelData[currentLevel]);

            textLevel.text = $"<size=50>LEVEL</size>\n<indent=6%><b>{currentLevel}</b></indent>";
        }

        public void ScoreIncreased()
        {
            score++;

            textCurrentScore.text = score.ToString();

            audioSource.Play();

            cameraController.ChangeBackgroundColour();
        }

        public void ResetTo(int level)
        {
            playerController.Reset();
            areaSpawner.Reset();
            cameraController.Reset();
            playerController.SetLevelTo(WaveioLevelData[level]);
            currentLevel = level;
            textLevel.text = $"<size=50>LEVEL</size>\n<indent=6%><b>{currentLevel}</b></indent>";

            gameStart = false;
            gameOver = false;
            score = 0;
            textCurrentScore.text = score.ToString();

            textTitle.gameObject.SetActive(true);
            textTapToPlay.gameObject.SetActive(true);

            textScore.gameObject.SetActive(false);
            textCurrentScore.gameObject.SetActive(false);
            textLevel.gameObject.SetActive(false);
            textBestScore.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(false);

            StartCoroutine(StartGame());
        }
    }
}
