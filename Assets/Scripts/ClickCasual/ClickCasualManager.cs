using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCasualManager : MonoBehaviour
{
    [SerializeField]
    private GameObject exitConfirmation;

    public void OnPinCircleButton()
    {
        SceneManagerEx.Scene.LoadScene((int)SceneManagerEx.SceneTypes.PinCircle);
    }

    public void OnWaveioButton()
    {
        SceneManagerEx.Scene.LoadScene((int)SceneManagerEx.SceneTypes.Waveio);
    }

    public void OnZigZagButton()
    {
        SceneManagerEx.Scene.LoadScene((int)SceneManagerEx.SceneTypes.ZigZag);
    }

    public void OnExitButton()
    {
        exitConfirmation.SetActive(true);
    }

    public void OnExitYesButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void OnExitNoButton()
    {
        exitConfirmation.SetActive(false);
    }

    public void Clear()
    {

    }
}
