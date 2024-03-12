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

    protected float spawningVelocityY = 3f;

    public override void Setup()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void UponCollision()
    {
        base.UponCollision();

        int random = Random.Range(0, itemList.Length);
        Item_Base item = itemList[random].GetComponent<Item_Base>();

        if (item.GetType() == typeof(Item_Coin))
        {
            if ( coinNumber > 0)
            {
                SpawnItem(item);
                coinNumber--;
            }

            if ( coinNumber == 0 )
            {
                SwitchToNoItemTile();
            }
        }
        else
        {
            SpawnItem(item);
            SwitchToNoItemTile();
        }
    }

    private void SpawnItem(Item_Base item)
    {
        GameObject go = Instantiate(item.gameObject, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1, 1), spawningVelocityY);
    }

    private void SwitchToNoItemTile()
    {
        spriteRenderer.sprite = noItemSprite;
        bounceable = false;
    }
}

