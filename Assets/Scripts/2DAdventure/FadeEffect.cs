using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Adventure2D
{
    public class FadeEffect : MonoBehaviour
    {
        public void FadeOn(Tilemap tilemap, float from, float to, float fadingTime)
        {
            StopAllCoroutines();
            StartCoroutine(StartFading(tilemap, from, to, fadingTime));
        }

        private IEnumerator StartFading(Tilemap tilemap, float from, float to, float fadingTime)
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
