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
        // Move the Menu Panel aside for the user
        ui_Mover.StartMoving(AfterStartButton, inactivePosition);
    }

    private void AfterStartButton()
    {
        // After the Menu Panel aside, Start the Game
        pinCircleManager.GameStart();
    }
    #endregion

    public void OnGameEnded()
    {
        // When the game has ended,
        ui_Mover.StartMoving(BringBackMenu, activePosition);
    }

    private void BringBackMenu()
    {
        pinCircleManager.Reset();
        // To-Do: Set up the scene to play again
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
