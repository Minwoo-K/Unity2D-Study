using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveioManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTitle;
    [SerializeField]
    private TextMeshProUGUI textTapToPlay;

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
}
