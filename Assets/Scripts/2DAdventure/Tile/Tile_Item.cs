using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Coin, Invincibility, HPPotion, Projectile, Random }

public class Tile_Item : Tile_Base
{
    [Header("Tile_Item Component")]
    [SerializeField]
    private ItemType itemType;
    [SerializeField]
    private GameObject[] items;
    [SerializeField]
    private Sprite emptyTileSprite;

    private SpriteRenderer spriteRenderer;
    private int coinCount = 5;
    private bool isEmpty = false;

    public override void Setup()
    {
        base.Setup();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void UponCollision()
    {
        if ( isEmpty ) return;

        base.UponCollision();

        SpawnItem();
    }

    private void SpawnItem()
    {
        if (itemType == ItemType.Random)
        {
            int index = Random.Range(0, items.Length - 1);

            itemType = (ItemType)index;
        }

        GameObject item = Instantiate(items[(int)itemType], transform.position, Quaternion.identity);
        if ( item.TryGetComponent<Item_Base>(out var itemSpawned) )
        {
            itemSpawned.OnSpawning();
        }

        if ( itemType == ItemType.Coin )
        {
            coinCount--;
        }

        if ( itemType != ItemType.Coin || coinCount == 0 )
        {
            isEmpty = true;
            spriteRenderer.sprite = emptyTileSprite;
        }
    }
}
