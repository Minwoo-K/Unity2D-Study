using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    private enum SceneTypes
    {
        //MainMenu,
        PinCircle,
        Waveio,
        ZigZag
    }

    // Singleton
    private static SceneManagerEx _scene;
    public static SceneManagerEx Scene { get { Init(); return _scene; } }

    // Initialize the Singleton
    private static void Init()
    {
        if (_scene == null)
        {
            GameObject sm = GameObject.Find("#SceneManager");
            if (sm == null)
            {
                sm = new GameObject() { name = "#SceneManager" };
                sm.AddComponent<DataManager>();
            }

            _scene = sm.GetComponent<SceneManagerEx>();
        }
    }

    private string[] GetAllScenes()
    {
        return Enum.GetNames(typeof(SceneTypes));
    }

    public void LoadScene(string name)
    {
        string[] sceneNames = GetAllScenes();

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
}
