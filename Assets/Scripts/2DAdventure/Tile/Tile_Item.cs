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
        base.UponCollision();

        if (itemType == ItemType.Random)
        {
            int index = Random.Range(0, items.Length - 1);

            itemType = (ItemType)index;
        }

        if ( IsHit ) return;

        IsHit = true;

        Debug.Log("Spawning an item");

        if ( ! isEmpty )
        {
            if (itemType == ItemType.Coin && coinCount != 0)
            {
                coinCount--;

                if (coinCount == 0)
                {
                    isEmpty = true;

                    spriteRenderer.sprite = emptyTileSprite;
                }
            }

            Instantiate(items[(int)itemType], transform.position, Quaternion.identity);

            if ( itemType != ItemType.Coin )
            {
                isEmpty = true;

                spriteRenderer.sprite = emptyTileSprite;
            }
        }

        IsHit = false;
    }
}
