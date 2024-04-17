using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Star : Item_Base
{
    [Tooltip("In each stage, 3 stars always exist and each has an index of 0, 1, or 2")]
    [SerializeField][Range(0, 2)]
    private int index;

    public override void UponTaken(GameObject player)
    {
        player.GetComponent<PlayerStat>().StarEarned(index);
    }
}
