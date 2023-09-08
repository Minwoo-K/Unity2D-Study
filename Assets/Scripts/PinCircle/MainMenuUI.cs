using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void OnStartButton()
    {
        Debug.Log("Game Start");
    }

    public void OnResetButton()
    {
        Debug.Log("Game Reset");
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
