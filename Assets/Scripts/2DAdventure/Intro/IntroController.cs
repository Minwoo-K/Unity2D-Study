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
                StartCoroutine(FadeEffect.FadeOn(pressAnyKey, 1, 0, textFadingTime));

                StartCoroutine(FadeEffect.FadeOn(pressAnyKey, 0, 1, textFadingTime));
            }
        }

        private void Update()
        {
            if ( IsKeyDown == true ) return;

            if ( Input.anyKeyDown )
            {
                IsKeyDown = true;

                StartCoroutine(FadeEffect.FadeOn(fadeScreen, 1, 0, 1, EventAfterFadingScreen));
            }
        }

        private void EventAfterFadingScreen()
        {
            Utils.LoadScene(SceneType.LevelSelection);
        }
    }
}


