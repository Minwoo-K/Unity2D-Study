using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class FadingEffect
{
    public static IEnumerator FadeOn(Tilemap tilemap, float from, float to, float fadeTime)
    {
        float percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / fadeTime;

            Color color = tilemap.color;
            color.a = Mathf.Lerp(from, to, percent);
            tilemap.color = color;

            yield return null;
        }
    }

    public static IEnumerator FadeOn(SpriteRenderer spriteRenderer, float from, float to, float fadeTime)
    {
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime / fadeTime;

            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(from, to, percent);
            spriteRenderer.color = color;

            yield return null;
        }
    }
}
