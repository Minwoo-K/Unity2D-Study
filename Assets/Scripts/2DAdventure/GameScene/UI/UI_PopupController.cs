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
    }
}
