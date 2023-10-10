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

        private void Start()
        {
            for ( int i = 0; i < fadeToStart.Length; i++ )
            {
                fadeToStart[i].StartFading();
            }
        }
    }
}
