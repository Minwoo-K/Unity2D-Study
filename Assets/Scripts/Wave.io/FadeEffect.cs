using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    private float fadeTime;

    private TextMeshProUGUI tmo;

    private void Start()
    {
        tmo = GetComponent<TextMeshProUGUI>();

        StartCoroutine(StartFadeEffect());
    }

    private IEnumerator StartFadeEffect()
    {
        while ( true )
        {
            yield return StartCoroutine(Fade(1, 0));

            yield return StartCoroutine(Fade(0, 1));
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0;
        float percent = 0;

        while ( percent < 1 )
        {
            current += Time.deltaTime;
            percent = current / fadeTime;

            Color opacity = tmo.color;
            opacity.a = Mathf.Lerp(start, end, percent);
            tmo.color = opacity;

            yield return null;
        }
    }
}
