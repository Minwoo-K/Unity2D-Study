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

    private int gameLevel;
    private AudioSource audioSource;
    private Dictionary<int, Data.PinCircleDatum> pinCircleLevelData = new Dictionary<int, Data.PinCircleDatum>();

    public bool gameStarted { private set; get; } = false;
    public bool gameClear { private set; get; } = false;
    public bool gameOver { private set; get; } = false;

    // Start the Game
    private void Start()
    {
        SetUpGame(1);
    }

    private void Update()
    {
        //if ( pinSpawner.throwablePins.Count == 0 && gameOver == false && gameStarted == true)
        //{
        //
        //    StartCoroutine(GameClear());
        //}
    }

    public void SetUpGame(int level)
    {
        if (pinCircleLevelData.Count == 0)
            pinCircleLevelData = DataManager.Data.PinCircle;

        gameLevel = level <= pinCircleLevelData.Count ? level : pinCircleLevelData.Count;
        numberOfThrowables = pinCircleLevelData[gameLevel].numberOfThrowablePins;
        numberOfStucks = pinCircleLevelData[gameLevel].numberOfStuckPins;

        audioSource = GetComponent<AudioSource>();
        pinSpawner.Setup(numberOfThrowables, numberOfStucks);
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
        audioSource.clip = gameClearSound;
        audioSource.Play();

        Debug.Log($"Game Level: {gameLevel} Cleared!");
        gameLevel++;

        StartCoroutine(ExitStage(0.5f, gameLevel));
    }

    public void GameOver()
    {
        gameOver = true;
        target.GetComponent<Rotator>().SetRotationSpeed(0);
        Camera.main.backgroundColor = gameOverColor;
        audioSource.clip = gameOverSound;
        audioSource.Play();

        Debug.Log($"Game Level: {gameLevel} Failed ):");

        StartCoroutine(ExitStage(1.0f, gameLevel));
    }

    public void ResetTo(int level)
    {
        Debug.Log($"Next Game Level: {gameLevel}");

        gameStarted = false;
        gameClear = false;
        gameOver = false;
        Camera.main.backgroundColor = gamePlayColor;
        target.GetComponent<Rotator>().Clear();
        pinSpawner.Clear();
        SetUpGame(level);
    }

    private IEnumerator ExitStage(float time, int level)
    {
        yield return new WaitForSeconds(time);

        mainMenu.OnGameEnded(level);
    }
}

