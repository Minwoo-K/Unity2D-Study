using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Adventure_2D
{
    public class IntroController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI pressAnyKey;
        [SerializeField]
        private float textFadingTime = 2f;
        [SerializeField]
        private Image fadeScreen;

        private bool IsKeyDown = false;

        private IEnumerator Start()
        {
            while ( true )
            {
                yield return StartCoroutine(FadeEffect.FadeOn(pressAnyKey, 1, 0, textFadingTime));

                yield return StartCoroutine(FadeEffect.FadeOn(pressAnyKey, 0, 1, textFadingTime));
            }
        }

        private void Update()
        {
            if ( IsKeyDown == true ) return;

            if ( Input.anyKeyDown )
            {
                IsKeyDown = true;

                StartCoroutine(FadeEffect.FadeOn(fadeScreen, 0, 1, 1, EventAfterFadingScreen));
            }
        }

        private void EventAfterFadingScreen()
        {
            Utils.LoadScene(SceneType.LevelSelection);
        }
    }
}


