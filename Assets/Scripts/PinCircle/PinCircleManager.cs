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

    public void GameClear()
    {
        stageClear = true;
        target.GetComponent<Rotator>().SetRotationSpeed(350);
        Camera.main.backgroundColor = gameClearColor;
    }

    public void GameOver()
    {

    }
}

