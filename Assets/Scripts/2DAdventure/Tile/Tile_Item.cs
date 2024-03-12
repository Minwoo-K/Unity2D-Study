using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Item : Tile_Base
{
    [Header("Tile_Item")]
    [SerializeField]
    private GameObject[] itemList;
    [SerializeField]
    private Sprite noItemSprite;

    private int coinNumber = 5;
    private SpriteRenderer spriteRenderer;

    public override void Setup()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void UponCollision()
    {
        base.UponCollision();

        SpawnItem();
    }

    private void SpawnItem()
    {
        int random = Random.Range(0, itemList.Length);
    }
}

