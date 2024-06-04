using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenArea : MonoBehaviour
{
    private float   fadingTime = 1.5f;
    
    private Tilemap tilemap;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            StopAllCoroutines();
            StartCoroutine(FadingEffect.FadingOn(tilemap, tilemap.color.a, 0, fadingTime));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(FadingEffect.FadingOn(tilemap, tilemap.color.a, 1, fadingTime - tilemap.color.a));
        }
    }
}
