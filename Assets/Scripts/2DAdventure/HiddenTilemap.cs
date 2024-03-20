using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenTilemap : MonoBehaviour
{
    private Tilemap tilemap;
    private Adventure2D.FadeEffect fadeEffect;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        fadeEffect = GetComponent<Adventure2D.FadeEffect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fadeEffect.FadeOn(tilemap, 1, 0, 2f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        fadeEffect.FadeOn(tilemap, 0, 1, 2f);
    }
}
