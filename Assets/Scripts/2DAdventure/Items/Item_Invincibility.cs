using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Invincibility : Item_Base
{
    public override void UpdateCollision(GameObject player)
    {
        player.GetComponent<PlayerStatus>().GetInvincible();
    }
}
