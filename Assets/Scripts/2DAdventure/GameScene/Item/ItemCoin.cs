using UnityEngine;

namespace Adventure_2D
{
    public class ItemCoin : ItemBase
    {
        public override void UpdateItemTaken(Transform transform)
        {
            transform.GetComponent<PlayerData>().Coin++;
        }
    }
}

