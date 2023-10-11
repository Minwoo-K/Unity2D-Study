using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class ZigZagManager : MonoBehaviour
    {
        [Header("GameStart UI")]
        [SerializeField]
        private UITextFadeEffect[] UIFadeToStart;

        private void Start()
        {
            for ( int i = 0; i < UIFadeToStart.Length; i++ )
            {
                UIFadeToStart[i].StartFading();
            }
        }
    }
}
