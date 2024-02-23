using System;
using UnityEngine.SceneManagement;

namespace Adventure_2D
{
    public enum SceneType { Intro=4, LevelSelection, Game }

    public static class Utils
    {
        public static string GetActiveScene()
        {
            return SceneManager.GetActiveScene().name;
        }
        
        public static void LoadScene(string sceneName="")
        {
            if ( string.IsNullOrEmpty(sceneName) )
            {
                SceneManager.LoadScene(GetActiveScene());
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }

        public static void LoadScene(SceneType sceneType)
        {
            LoadScene((int)sceneType);
        }

        public static void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

