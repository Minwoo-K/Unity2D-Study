using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehaviours : MonoBehaviour
{
    public void OnStartButton()
    {
        Debug.Log("Start Button");
    }

    public void OnResetButton()
    {
        Debug.Log("Reset Button");
    }

    public void OnExitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
