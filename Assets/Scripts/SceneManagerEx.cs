using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : MonoBehaviour
{
    public enum SceneTypes
    {
        MainMenu,
        PinCircle,
        Waveio,
        ZigZag
    }

    // Singleton
    private static SceneManagerEx _scene;
    public static SceneManagerEx Scene { get { Init(); return _scene; } }

    private string[] sceneNames = null;

    // Initialize the Singleton
    private static void Init()
    {
        if (_scene == null)
        {
            GameObject sm = GameObject.Find("#SceneManager");
            if (sm == null)
            {
                sm = new GameObject() { name = "#SceneManager" };
                sm.AddComponent<SceneManagerEx>();
            }

            _scene = sm.GetComponent<SceneManagerEx>();

            _scene.sceneNames = _scene.GetAllScenes();
        }
    }

    private string[] GetAllScenes()
    {
        return Enum.GetNames(typeof(SceneTypes));
    }

    public void LoadScene(string name)
    {
        for ( int i = 0; i < sceneNames.Length; i++ )
        {
            if ( name.Equals(sceneNames[i]) )
            {
                SceneManager.LoadScene(i);
                return;
            }
        }

        Debug.LogError($"Couldn't find a scene named [{name}] in the scene list registered. Please check again.");
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(sceneNames[index]);
    }

    public string[] GetAllSceneNames()
    {
        return sceneNames;
    }
}
