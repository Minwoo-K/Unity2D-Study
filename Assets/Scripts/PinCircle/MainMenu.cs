using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private PinCircleManager pinCircleManager;
    [SerializeField]
    private UI_Mover ui_Mover;

    private SceneManagerEx sceneManager;
    private Vector3 inactivePosition = Vector3.right * 1080;
    private Vector3 activePosition = Vector3.zero;

    public int gameLevel { private set; get; } = 0;

    private void Awake()
    {
        sceneManager = new SceneManagerEx();
    }

    #region START button
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

    #region RESET button
    public void OnResetButton()
    {
        pinCircleManager.ResetTo(1);
        Debug.Log("Game has been reset");
    }
    #endregion

    #region EXIT button
    public void OnExitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    #endregion

    public void OnGameEnded(int level)
    {
        // When the game has ended,
        ui_Mover.StartMoving(BringBackMenu, activePosition);
        // Deliver the game level that should be set up
        gameLevel = level;
    }

    private void BringBackMenu()
    {
        //sceneManager.LoadScene("PinCircle");
        pinCircleManager.ResetTo(gameLevel);
    }
}
