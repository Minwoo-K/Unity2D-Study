using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Star : Item_Base
{
    [SerializeField, Range(0, 2)]
    private int index;

    public override void UpdateCollision(GameObject player)
    {
        player.GetComponent<PlayerStatus>().FillStar(index);
    }
}
