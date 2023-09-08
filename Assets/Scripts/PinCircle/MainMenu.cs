using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private PinCircleManager pinCircleManager;
    [SerializeField]
    private UI_Mover ui_Mover;

    private Vector3 inactivePosition = Vector3.right * 1080;
    private Vector3 activePosition = Vector3.zero;

    #region START
    public void OnStartButton()
    {
        Debug.Log("Start Button");
        ui_Mover.StartMoving(AfterStartButton, inactivePosition);
    }

    private void AfterStartButton()
    {
        pinCircleManager.GameStart();
    }
    #endregion

    public void OnGameEnded()
    {
        ui_Mover.StartMoving(BringBackMenu, activePosition);
    }

    private void BringBackMenu()
    {
       
    }

    #region RESET
    public void OnResetButton()
    {
        Debug.Log("Reset Button");
    }
    #endregion

    #region EXIT
    public void OnExitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    #endregion
}
