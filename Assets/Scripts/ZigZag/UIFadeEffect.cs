using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ZigZag
{
    public class UIFadeEffect : MonoBehaviour
    {
        [SerializeField]
        private float fadeTime;
        [SerializeField]
        private AnimationCurve fadeCurve;

        private TextMeshProUGUI tmp;
        private float endAlpha = 1;

        private void Awake()
        {
            tmp = GetComponent<TextMeshProUGUI>();
            endAlpha = tmp.color.a;
        }

        public void StartFading()
        {
            StartCoroutine(Fade(0, endAlpha));
        }

        private IEnumerator Fade(float start, float end)
        {
            float current = 0;
            float percent = 0;

            while ( percent < 1 )
            {
                current += Time.deltaTime;
                percent = current / fadeTime;

                Color color = tmp.color;
                color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
                tmp.color = color;

                yield return null;
            }
        }
    }
}
