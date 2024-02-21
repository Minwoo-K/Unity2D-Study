using UnityEngine.SceneManagement;

namespace Adventure_2D
{
    public enum SceneType { Intro=0, LevelSelection, Game }

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
            SceneManager.LoadScene(sceneType.ToString());
        }
    }
}

