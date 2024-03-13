using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Item : Tile_Base
{
    [Header("Tile_Item")]
    [SerializeField]
    private ItemType itemType = ItemType.Random;
    [SerializeField]
    private GameObject[] itemPrefabs;
    [SerializeField]
    private Sprite emptyTileSprite;

    private SpriteRenderer spriteRenderer;
    private bool isEmpty = false;
    private int coinCount = 5;

    private float collisionCooltime = 0.2f;
    private bool  collisionReady = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Setup()
    {
        
    }

    public override void UponCollision()
    {
        base.UponCollision();

        if ( collisionReady ) StartCoroutine(CollisionCooldown());
        else                  return;

        if ( isEmpty ) return;

        Debug.Log("Item Spawning");

        if ( itemType == ItemType.Random )
        {
            itemType = (ItemType) Random.Range(0, itemPrefabs.Length);
        }

        if ( itemType == ItemType.Coin )
        {
            coinCount--;
        }

        SpawnItem();

        if ( itemType != ItemType.Coin || coinCount == 0 )
        {
            SwitchToEmptyTile();
        }

        Hit = false;
    }

    private void SpawnItem()
    {
        GameObject go = Instantiate(itemPrefabs[(int)itemType], transform.position, Quaternion.identity);
    }

    private void SwitchToEmptyTile()
    {
        isEmpty = true;
        spriteRenderer.sprite = emptyTileSprite;
        //bounceable = false;
    }

    private IEnumerator CollisionCooldown()
    {
        collisionReady = false;

        yield return new WaitForSeconds(collisionCooltime);

        collisionReady = true;
    }
}

