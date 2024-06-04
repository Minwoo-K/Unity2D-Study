using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class FadingEffect
{
    public static IEnumerator FadingOn(Tilemap target, float start, float end, float time)
    {
        float percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / time;

            Color color = target.color;
            color.a = Mathf.Lerp(start, end, percent);
            target.color = color;

            yield return null;
        }
    }
}
