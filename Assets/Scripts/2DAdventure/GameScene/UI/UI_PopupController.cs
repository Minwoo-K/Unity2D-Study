using UnityEngine;

namespace Adventure_2D
{
    public class UI_PopupController : MonoBehaviour
    {
        [Header("Common: Black Overlay Panel")]
        [SerializeField]
        private GameObject overlayPanel;

        [Header("Pause Menu")]
        [SerializeField]
        private GameObject pauseMenu;

        [Header("Level Failed")]
        [SerializeField]
        private GameObject levelFailedPanel;

        [Header("Level Complete")]
        [SerializeField]
        private GameObject levelCompletePanel;
        [SerializeField]
        private GameObject[] starObjects;

        private void SetTimeScale(float time)
        {
            Time.timeScale = time;
        }

        public void PauseButton()
        {
            SetTimeScale(0);
            overlayPanel.SetActive(true);
            pauseMenu.SetActive(true);
        }

        public void Resume()
        {
            SetTimeScale(1);
            overlayPanel.SetActive(false);
            pauseMenu.SetActive(false);
        }

        public void LevelFailed()
        {
            SetTimeScale(0);
            overlayPanel.SetActive(true);
            levelFailedPanel.SetActive(true);
        }

        public void LevelComplete(bool[] starsEarned)
        {
            SetTimeScale(0);
            overlayPanel.SetActive(true);
            levelCompletePanel.SetActive(true);

            for ( int i = 0; i < starsEarned.Length; i ++ )
            {
                starObjects[i].SetActive(starsEarned[i]);
            }
        }

        public void Restart()
        {
            SetTimeScale(1);
            Utils.LoadScene();
        }

        public void SelectLevelButton()
        {
            SetTimeScale(1);
            Utils.LoadScene(SceneType.LevelSelection);
        }

        public void NextLevelButton()
        {
            SetTimeScale(1);
            Utils.LoadScene();
        }
    }
}
