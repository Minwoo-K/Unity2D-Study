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

    private string[] GetAllScenes()
    {
        return Enum.GetNames(typeof(SceneTypes));
    }
}
