using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Adventure2D
{
    public static class FadeEffect
    {
        public static IEnumerator FadeOn(Tilemap tilemap, float from, float to, float fadingTime, Action eventAfter=null)
        {
            float timePercent = 0;

            while ( timePercent < 1 )
            {
                timePercent += Time.deltaTime / fadingTime;

                Color color = tilemap.color;
                color.a = Mathf.Lerp(from, to, timePercent);
                tilemap.color = color;

                yield return null;
            }

            if ( eventAfter != null ) eventAfter.Invoke();
        }
    }
}
