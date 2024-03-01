using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    // Reviewed all codes to start over from a scratch
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private StageData[] allStageData;
        [SerializeField]
        private GameObject[] levelPrefabs;
        [SerializeField]
        private PlayerController playerController;
        [SerializeField]
        private CameraOnTarget cameraController;
        [SerializeField]
        private UI_PopupController ui_Controller;
        [SerializeField]
        private PlayerData playerData;

        private int currentLevel = 1;
        private bool isLevelComplete = false;
        private bool isLevelFailed = false;

        private void Awake()
        {
            currentLevel = PlayerPrefs.GetInt(Define.CurrentLevel);
            playerData.Coin = PlayerPrefs.GetInt(Define.Coins);

            GameObject stage = Instantiate(levelPrefabs[currentLevel-1]);
            ItemStar[] itemStars = stage.GetComponentsInChildren<ItemStar>();

            (bool, bool[]) levelData = Define.LoadLevelData(currentLevel);
            for ( int i = 0; i < levelData.Item2.Length; i++ )
            {
                if ( levelData.Item2[i] )
                {
                    playerData.GetStar(i);
                    
                    for ( int index = 0; index < itemStars.Length; index++ )
                    {
                        if ( itemStars[index].StarIndex == i )
                        {
                            itemStars[index].gameObject.SetActive(false);
                        }
                    }
                }
            }

            playerController.Setup(allStageData[currentLevel-1]);
            cameraController.Setup(allStageData[currentLevel-1]);
        }

        public void OnDie()
        {
            if ( isLevelFailed ) return;

            isLevelFailed = true;

            ui_Controller.LevelFailed();
        }

        public void LevelComplete()
        {
            if ( isLevelComplete ) return;

            isLevelComplete = true;

            ui_Controller.LevelComplete(playerData.StarsEarned);
            Define.SaveUponLevelComplete(currentLevel, playerData.StarsEarned, playerData.Coin);
        }
    }
}

