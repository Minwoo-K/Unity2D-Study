using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Adventure2D
{
    public class FadeEffect : MonoBehaviour
    {
        public IEnumerator OnFade(Tilemap tilemap, float from, float to, float fadingTime)
        {
            float percent = 0;

            while ( percent < 1 )
            {
                percent += Time.deltaTime / fadingTime;

                Color color = tilemap.color;
                color.a = Mathf.Lerp(from, to, percent);

                yield return null;
            }
        }
    }
}
