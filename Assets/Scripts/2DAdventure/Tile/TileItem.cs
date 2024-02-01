using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class TileItem : TileBase
    {
        [Header("Tile Item Component")]
        [SerializeField]
        private ItemType itemType = ItemType.Random;
        [SerializeField]
        private GameObject[] items;
        [SerializeField]
        private int coinCount = 5;
        [SerializeField]
        private Sprite nonBrokeTile_sprite;

        private bool isEmpty = false;

        public override void UpdateCollsion()
        {
            if ( isEmpty ) return;

            base.UpdateCollsion();

            SpawnItem();

            IsHit = false;
        }

        private void SpawnItem()
        {
            if ( itemType == ItemType.Random )
            {
                itemType = (ItemType)Random.Range(0, items.Length);
            }

            Instantiate(items[(int)itemType], transform.position, Quaternion.identity);

            if ( itemType == ItemType.Coin )
            {
                coinCount --;
            }

            if ( itemType != ItemType.Coin || (itemType == ItemType.Coin && coinCount == 0) )
            {
                GetComponent<SpriteRenderer>().sprite = nonBrokeTile_sprite;

                isEmpty = true;
            }
        }
    }
}
