using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

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
    }
}


