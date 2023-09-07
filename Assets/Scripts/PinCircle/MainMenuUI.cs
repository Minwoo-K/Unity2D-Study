using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private PinCircleManager pinCircleManager;
    [SerializeField]
    private UI_Mover ui_Mover;

    private Vector3 inactiveMenu = Vector3.right * 1080;
    private Vector3 activeMenu = Vector3.zero;

    public void OnStartButton()
    {
        ui_Mover.StartMoving(EventOnStart, inactiveMenu);
    }

    private void EventOnStart()
    {
        Debug.Log("Game Start");
        pinCircleManager.GameStart();
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
