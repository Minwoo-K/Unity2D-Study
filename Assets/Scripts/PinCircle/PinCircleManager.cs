using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCircleManager : MonoBehaviour
{
    [SerializeField]
    private PinSpawner pinSpawner;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private int numberOfThrowables;
    [SerializeField]
    private int numberOfStucks;
    [SerializeField]
    private Color gamePlayColor;
    [SerializeField]
    private Color gameClearColor;
    [SerializeField]
    private Color gameOverColor;

    public bool gameStarted { private set; get; } = false;
    public bool stageClear { private set; get; } = false;
    public bool stageOver { private set; get; } = false;

    private void Start()
    {
        pinSpawner.Setup(numberOfThrowables, numberOfStucks);
    }

    private void Update()
    {
        if ( pinSpawner.throwablePins.Count == 0 )
        {
            Debug.Log("Game Clear");
            GameClear();
        }
    }

    public void GameStart()
    {
        gameStarted = true;
        target.GetComponent<Rotator>().SetRotationSpeed(80);
    }

    public void GameClear()
    {
        stageClear = true;
        target.GetComponent<Rotator>().SetRotationSpeed(350);
        Camera.main.backgroundColor = gameClearColor;
    }

    public void GameOver()
    {
        stageOver = true;
        target.GetComponent<Rotator>().SetRotationSpeed(0);
        Camera.main.backgroundColor = gameOverColor;
    }

    public void Reset()
    {
        stageClear = false;
        stageOver = false;
        Camera.main.backgroundColor = gamePlayColor;
        target.GetComponent<Rotator>().Clear();
    }
}

