using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Adventure_2D
{
    public class HiddenArea : MonoBehaviour
    {
        private Tilemap tilemap;

        private void Awake()
        {
            tilemap = GetComponent<Tilemap>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                StopAllCoroutines();
                StartCoroutine(FadeEffect.FadeOn(tilemap, tilemap.color.a, 0, tilemap.color.a));
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                StopAllCoroutines();
                StartCoroutine(FadeEffect.FadeOn(tilemap, tilemap.color.a, 1, 1 - tilemap.color.a));
            }
        }
    }
}
