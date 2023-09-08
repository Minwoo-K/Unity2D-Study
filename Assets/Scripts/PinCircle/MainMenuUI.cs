using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        ui_Mover.StartMoving(EventOnGameStart, inactiveMenu);
    }

    private void EventOnGameStart()
    {
        Debug.Log("Game Start");
        pinCircleManager.GameStart();
    }

    public void BringBackMenu()
    {
        if ( pinCircleManager.stageOver == true )
        {
            ui_Mover.StartMoving(EventOnGameOver, activeMenu);
        }

        if ( pinCircleManager.stageClear == true)
        {
            ui_Mover.StartMoving(EventOnGameClear, activeMenu);
        }
    }

    public void EventOnGameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EventOnGameClear()
    {
        Debug.Log("Game Clear");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
