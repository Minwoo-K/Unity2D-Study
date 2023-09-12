using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCircleManager : MonoBehaviour
{
    [Header("Essential Settings")]
    [SerializeField]
    private PinSpawner pinSpawner;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private MainMenu mainMenu;

    [Header("The Number of Pins Settings")]
    [SerializeField]
    private int numberOfThrowables;
    [SerializeField]
    private int numberOfStucks;

    [Header("In-Game Background Color Settings")]
    [SerializeField]
    private Color gamePlayColor;
    [SerializeField]
    private Color gameClearColor;
    [SerializeField]
    private Color gameOverColor;

    [SerializeField]
    private AudioClip gameClearSound;
    [SerializeField]
    private AudioClip gameOverSound;

    private AudioSource audioSource;

    public bool gameStarted { private set; get; } = false;
    public bool gameClear { private set; get; } = false;
    public bool gameOver { private set; get; } = false;

    private void Start()
    {
        pinSpawner.Setup(numberOfThrowables, numberOfStucks);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if ( pinSpawner.throwablePins.Count == 0 && gameOver == false && gameStarted == true)
        {
            StartCoroutine(GameClear());
        }

        
    }

    public void GameStart()
    {
        gameStarted = true;
        target.GetComponent<Rotator>().SetRotationSpeed(80);
    }

    public IEnumerator GameClear()
    {
        yield return new WaitForSeconds(0.1f);

        if (gameOver == true)
        {
            yield break;
        }

        gameClear = true;
        target.GetComponent<Rotator>().SetRotationSpeed(350);
        Camera.main.backgroundColor = gameClearColor;

        StartCoroutine(ExitStage(0.5f));
    }

    public void GameOver()
    {
        gameOver = true;
        target.GetComponent<Rotator>().SetRotationSpeed(0);
        Camera.main.backgroundColor = gameOverColor;
        audioSource.clip = gameOverSound;
        audioSource.Play();

        StartCoroutine(ExitStage(1.0f));
    }

    public void Reset(int numberOfThrowables, int numberOfStucks)
    {
        gameStarted = false;
        gameClear = false;
        gameOver = false;
        Camera.main.backgroundColor = gamePlayColor;
        target.GetComponent<Rotator>().Clear();
        pinSpawner.Clear();
    }

    private IEnumerator ExitStage(float time)
    {
        yield return new WaitForSeconds(time);

        mainMenu.OnGameEnded();
    }
}

