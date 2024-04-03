using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Random, Coin, Invincibility, HPPotion, Projectile }

public class Tile_Item : Tile_Base
{
    [Header("Tile_Item Component")]
    [SerializeField]
    private ItemType itemType;
    [SerializeField]
    private GameObject[] items;

    public override void UponCollision()
    {
        base.UponCollision();

        if ( itemType == ItemType.Random )
        {

        }
    }
}
