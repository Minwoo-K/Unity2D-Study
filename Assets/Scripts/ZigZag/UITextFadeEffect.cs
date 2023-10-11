using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ZigZag
{
    public class UITextFadeEffect : MonoBehaviour
    {
        [SerializeField]
        private float fadeTime;
        [SerializeField]
        private AnimationCurve curve;

        private TextMeshProUGUI tmo;
        private float alpha;

        private void Awake()
        {
            tmo = GetComponent<TextMeshProUGUI>();
            alpha = tmo.color.a;
        }

        public void StartFading()
        {
            StartCoroutine(FadeIn(0, alpha));
        }

        private IEnumerator FadeIn(float start, float end)
        {
            float current = 0;
            float percent = 0;

            while ( percent < 1 )
            {
                current += Time.deltaTime;
                percent = current / fadeTime;

                Color color = tmo.color;
                color.a = curve.Evaluate(percent);
                tmo.color = color;

                yield return null;
            }
        }
    }
}
