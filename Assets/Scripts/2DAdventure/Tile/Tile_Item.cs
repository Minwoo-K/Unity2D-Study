using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Item : Tile_Base
{
    [Header("Tile_Item")]
    [SerializeField]
    private ItemType itemType = ItemType.Random;
    [SerializeField]
    private GameObject[] itemList;
    [SerializeField]
    private Sprite noItemSprite;

    private int coinNumber = 5;
    private bool isEmpty = false;

    private SpriteRenderer spriteRenderer;
    protected float spawningVelocityY = 3f;

    public override void Setup()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void UponCollision()
    {
        if ( isEmpty ) return;

        base.UponCollision();

        if ( itemType == ItemType.Random )
        {
            itemType = (ItemType)Random.Range(0, itemList.Length);
        }

        if ( itemType == ItemType.Coin )
        {
            coinNumber--;
        }

        SpawnItem();

        if ( itemType != ItemType.Coin || coinNumber == 0 ) SwitchToEmptyTile();
    }

    private void SpawnItem()
    {
        GameObject item = Instantiate(itemList[(int)itemType], transform.position, Quaternion.identity);
    }

    private void SwitchToEmptyTile()
    {
        isEmpty = true;
        spriteRenderer.sprite = noItemSprite;
        bounceable = false;
    }
}

