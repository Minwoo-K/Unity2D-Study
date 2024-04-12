using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_HPPotion : Item_Base
{
    public override void UponTaken(GameObject player)
    {
        player.GetComponent<PlayerStat>().IncreaseLife();
    }
}
