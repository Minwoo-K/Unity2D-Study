using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace Adventure_2D
{
    public static class FadeEffect
    {
        public static IEnumerator FadeOn(Tilemap tilemap, float startAlpha, float endAlpha, float fadeTime=1, Action action=null)
        {
            float percent = 0;

            while ( percent < 1 )
            {
                percent += Time.deltaTime / fadeTime;
                Color color = tilemap.color;
                color.a = Mathf.Lerp(startAlpha, endAlpha, percent);
                tilemap.color = color;

                yield return null;
            }

            // if ( action != null ) action.Invoke(); ==
            action?.Invoke();
        }

        public static IEnumerator FadeOn(SpriteRenderer sprite, float startAlpha, float endAlpha, float fadeTime = 1, Action action = null)
        {
            float percent = 0;

            while (percent < 1)
            {
                percent += Time.deltaTime / fadeTime;
                Color color = sprite.color;
                color.a = Mathf.Lerp(startAlpha, endAlpha, percent);
                sprite.color = color;

                yield return null;
            }

            // if ( action != null ) action.Invoke(); ==
            action?.Invoke();
        }

        public static IEnumerator FadeOn(Image image, float startAlpha, float endAlpha, float fadeTime = 1, Action action = null)
        {
            float percent = 0;

            while (percent < 1)
            {
                percent += Time.deltaTime / fadeTime;
                Color color = image.color;
                color.a = Mathf.Lerp(startAlpha, endAlpha, percent);
                image.color = color;

                yield return null;
            }

            // if ( action != null ) action.Invoke(); ==
            action?.Invoke();
        }

        public static IEnumerator FadeOn(TextMeshProUGUI text, float startAlpha, float endAlpha, float fadeTime = 1, Action action = null)
        {
            float percent = 0;

            while (percent < 1)
            {
                percent += Time.deltaTime / fadeTime;
                Color color = text.color;
                color.a = Mathf.Lerp(startAlpha, endAlpha, percent);
                text.color = color;

                yield return null;
            }

            // if ( action != null ) action.Invoke(); ==
            action?.Invoke();
        }
    }
}


