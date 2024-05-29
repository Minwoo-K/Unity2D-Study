using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType { Coin, Invincibility, HPPotion, Projectile, Random }

public class Tile_Item : Tile_Base
{
    [SerializeField]
    private ItemType itemType;
    [SerializeField]
    private GameObject[] itemList;
    [SerializeField]
    private Sprite emptyTileSprite;

    private bool spawning = false;
    private int coinCount = 5;
    private bool IsEmpty { get; set; } = false;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void UpdateCollision()
    {
        base.UpdateCollision();

        if ( IsEmpty || spawning ) return;

        spawning = true;

        if ( itemType == ItemType.Random )
        {
            int random = Random.Range(0, itemList.Length);
            itemType = (ItemType)random;
        }

        SpawnItem((int)itemType);

        if ( itemType == ItemType.Coin )
        {
            coinCount--;

            if ( coinCount == 0 )
            {
                IsEmpty = true;
            }
        }
        else
        {
            IsEmpty = true;
        }

        if ( IsEmpty )
        {
            spriteRenderer.sprite = emptyTileSprite;
            bounceable = false;
        }

        spawning = false;
    }

    private void SpawnItem(int index)
    {
        Instantiate(itemList[index], transform.position, Quaternion.identity);
    }
}
