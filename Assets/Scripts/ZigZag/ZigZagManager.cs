using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class ZigZagManager : MonoBehaviour
    {
        [Header("UI Configuration")]
        [SerializeField]
        private UIFadeEffect[] fadeToStart;     // UI objects to fade at start

        public bool GameStart { get; private set; } = false;

        private IEnumerator Start()
        {
            for (int i = 0; i < fadeToStart.Length; i++)
            {
                fadeToStart[i].StartFading();
            }

            while ( true )
            {
                if ( Input.GetMouseButtonDown(0) )
                {
                    OnGameStart();

                    yield break;
                }

                yield return null;
            }
        }

        private void OnGameStart()
        {
            GameStart = true;

            for ( int i = 0; i < fadeToStart.Length; i++ )
            {
                fadeToStart[i].gameObject.SetActive(false);
            }
        }
    }
}
