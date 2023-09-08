using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCircleManager : MonoBehaviour
{
    [SerializeField]
    private PinSpawner pinSpawner;
    [SerializeField]
    private Transform target;

    [Header("Settings of The Initial Number of Pins")]
    [SerializeField]
    private int numberOfThrowables;
    [SerializeField]
    private int numberOfStucks;

    [Header("GamePlay Color Configuration")]
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
            GameClear();
        }
    }

    public void GameStart()
    {
        gameStarted = true;
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
        gameStarted = false;
        stageClear = false;
        stageOver = false;
        Camera.main.backgroundColor = gamePlayColor;
        target.GetComponent<Rotator>().SetRotationSpeed(80);
    }

}

