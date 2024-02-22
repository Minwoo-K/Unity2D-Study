using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Adventure_2D
{
    public class LevelSelectionController : MonoBehaviour
    {
        [Header("Fading Screen")]
        [SerializeField]
        private Image fadingScreen;

        [Header("Level UI")]
        [SerializeField]
        private UILevel levelUI_Prefab;
        [SerializeField]
        private Transform levelUI_Parent;

        private void Awake()
        {
            StartCoroutine(FadeEffect.FadeOn(fadingScreen, 1, 0, 1, EventAfterFadingScreen));
            LoadAllLevelData();
        }

        private void EventAfterFadingScreen()
        {
            fadingScreen.gameObject.SetActive(false);
        }

        private void LoadAllLevelData()
        {
            // Unlock level 1
            PlayerPrefs.SetInt($"1{Define.LevelUnlocked}", 1);

            for ( int level = 1; level <= Define.MaxLevel; level++ )
            {
                UILevel levelUI = Instantiate(levelUI_Prefab, levelUI_Parent);
                // (bool, bool[]) levelData = Define.LoadLevelData(level);
                (bool isUnlocked, bool[] starsEarned) = Define.LoadLevelData(level);

                // levelUI.SetLevel(level, levelData.Item1, levelData.Item2, fadingScreen);
                levelUI.SetLevel(level, isUnlocked, starsEarned, fadingScreen);
            }
        }

        [ContextMenu("Reset Level Data")]
        private void ResetLevelData()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}

