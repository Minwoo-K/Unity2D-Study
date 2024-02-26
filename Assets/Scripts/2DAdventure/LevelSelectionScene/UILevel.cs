using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Adventure_2D
{
    public class UILevel : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Sprite spriteLevelLocked;
        [SerializeField]
        private Image levelIcon;
        [SerializeField]
        private TextMeshProUGUI level_Text;
        [SerializeField]
        private GameObject starBackgroundObject;
        [SerializeField]
        private GameObject[] starsObjects;

        private int level;
        private bool isUnlocked;
        private Image fadingScreen;

        public void SetLevel(int level, bool isUnlocked, bool[] starsEarned, Image fadingScreen)
        {
            this.level = level;
            this.isUnlocked = isUnlocked;
            this.fadingScreen = fadingScreen;

            if ( isUnlocked )
            {
                level_Text.enabled = true;
                level_Text.text = level.ToString(); 
                
                for (int i = 0; i < starsObjects.Length; i++)
                {
                    starsObjects[i].SetActive(starsEarned[i]);
                }
            }
            else
            {
                levelIcon.sprite = spriteLevelLocked;
                level_Text.enabled = false;
                starBackgroundObject.SetActive(false);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if ( isUnlocked )
            {
                fadingScreen.gameObject.SetActive(true);
                StartCoroutine(FadeEffect.FadeOn(fadingScreen, 0, 1, 1, EventAfterFadingScreen));
            }
        }

        private void EventAfterFadingScreen()
        {
            PlayerPrefs.SetInt(Define.CurrentLevel, level);
            Utils.LoadScene(SceneType.Game);
        }
    }
}
