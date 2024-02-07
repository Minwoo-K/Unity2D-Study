using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int coin;

    public int Coin
    {
        set => Mathf.Clamp(coin, 0, 9999);
        get => coin;
    }
}
