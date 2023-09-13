using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCircleManager : MonoBehaviour
{
    [Header("Essential Settings")]
    [SerializeField]
    private PinSpawner pinSpawner;      // The Pin Spawner component
    [SerializeField]
    private Transform target;           // Target Transform
    [SerializeField]
    private MainMenu mainMenu;          // The Main Menu Component

    [Header("The Number of Pins Settings")]
    [SerializeField]
    private int numberOfThrowables;     // The Number of Throwable Pins in each stage
    [SerializeField]
    private int numberOfStucks;         // The Number of Stuck Pins in each stage

    [Header("In-Game Background Color Settings")]
    [SerializeField]
    private Color gamePlayColor;        // Background Color during Game Play
    [SerializeField]
    private Color gameClearColor;       // Background Color on Game Clear
    [SerializeField]
    private Color gameOverColor;        // Background Color on Game Over

    [SerializeField]
    private AudioClip gameClearSound;   // An Audio Clip upon Game Clear
    [SerializeField]
    private AudioClip gameOverSound;    // An Audio Clip upon Game Over

    private int gameLevel;
    private AudioSource audioSource;    // AudioSource to play audio
    // Dictionary to hold level data
    private Dictionary<int, Data.PinCircleDatum> pinCircleLevelData = null;

    // Flags
    public bool gameStarted { private set; get; } = false;
    public bool gameClear { private set; get; } = false;
    public bool gameOver { private set; get; } = false;

    // Start the Game
    private void Start()
    {
        SetUpGame(1);
    }

    public void SetUpGame(int level)
    {
        // if the Dictionary hasn't been initialized
        if (pinCircleLevelData == null)
        {
            // Initialize the Dictionary
            pinCircleLevelData = new Dictionary<int, Data.PinCircleDatum>();
            // Fetch the Level Data from DataManager
            pinCircleLevelData = DataManager.Data.PinCircle;
        }

        // Applying Level Data
        // The Level is always equal to or same as the maximum level configured
        gameLevel = level <= pinCircleLevelData.Count ? level : pinCircleLevelData.Count;
        // Fetch the number of pins
        numberOfThrowables = pinCircleLevelData[gameLevel].numberOfThrowablePins;
        numberOfStucks = pinCircleLevelData[gameLevel].numberOfStuckPins;
        // Set target speed
        target.GetComponent<TargetRotator>().SetRotationSpeed(pinCircleLevelData[gameLevel].targetSpeed);

        // Get AudioSource component
        audioSource = GetComponent<AudioSource>();
        // Get PinSpawner to spawn the given numbers of pins
        pinSpawner.Setup(numberOfThrowables, numberOfStucks);
    }

    public void GameStart()
    {
        gameStarted = true;
    }

    // On GameClear
    public IEnumerator GameClear()
    {
        // Wait for 0.1 second to see if the flag "gameOver" turns on. 
        yield return new WaitForSeconds(0.1f);

        //If it does, the game isn't clear
        if (gameOver == true)
        {
            yield break;
        }

        // GameClear settings
        gameClear = true;
        target.GetComponent<TargetRotator>().SetRotationSpeed(350);
        Camera.main.backgroundColor = gameClearColor;
        audioSource.clip = gameClearSound;
        audioSource.Play();

        Debug.Log($"Game Level: {gameLevel} Cleared!");
        // as the game was clear, the game level increases
        gameLevel++;
        // Exit the game and send the next game level
        StartCoroutine(ExitStage(0.5f, gameLevel));
    }

    // On GameOver
    public void GameOver()
    {
        gameOver = true;
        target.GetComponent<TargetRotator>().SetRotationSpeed(0);
        Camera.main.backgroundColor = gameOverColor;
        audioSource.clip = gameOverSound;
        audioSource.Play();

        Debug.Log($"Game Level: {gameLevel} Failed ):");
        // Exit the game and send the same game level
        StartCoroutine(ExitStage(1.0f, gameLevel));
    }

    // Reset the game to a certain level
    public void ResetTo(int level)
    {
        gameStarted = false;
        gameClear = false;
        gameOver = false;
        Camera.main.backgroundColor = gamePlayColor;
        pinSpawner.Clear();
        SetUpGame(level);
    }

    // Exit the game within the given time and the level stage for the next game
    private IEnumerator ExitStage(float time, int level)
    {
        yield return new WaitForSeconds(time);

        mainMenu.OnGameEnded(level);
    }
}

