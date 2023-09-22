using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveioManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTitle;
    [SerializeField]
    private TextMeshProUGUI textTapToPlay;
    [SerializeField]
    private GameObject continueButton;

    public bool gameOver { get; private set; } = false;

    private IEnumerator Start()
    {
        while ( true )
        {
            if ( Input.GetMouseButtonDown(0) )
            {
                StartGame();

                yield break;
            }

            yield return null;
        }
    }

    private void Update()
    {
        
    }

    private void StartGame()
    {
        textTitle.gameObject.SetActive(false);
        textTapToPlay.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOver = true;

        continueButton.SetActive(true);
    }

    public void OnContinueButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
