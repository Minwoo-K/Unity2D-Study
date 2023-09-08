using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehaviours : MonoBehaviour
{
    [SerializeField]
    private PinCircleManager pinCircleManager;
    [SerializeField]
    private UI_Mover ui_Mover;

    private Vector3 inactivePosition = Vector3.right * 1080;
    private Vector3 activePosition = Vector3.zero;

    public void OnStartButton()
    {
        Debug.Log("Start Button");
        ui_Mover.StartMoving(AfterStartButton, inactivePosition);
    }

    private void AfterStartButton()
    {
        pinCircleManager.GameStart();
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
