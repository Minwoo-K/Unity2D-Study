using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Adventure2D
{
    public static class FadeEffect
    {
        public static IEnumerator FadeOn(Tilemap tilemap, float from, float to, float fadingTime=1, Action action =null)
        {
            float percent = 0;

            while ( percent < 1 )
            {
                percent += Time.deltaTime / fadingTime;

                Color color = tilemap.color;
                color.a = Mathf.Lerp(from, to, percent);
                tilemap.color = color;

                yield return null;
            }
        }
    }
}
