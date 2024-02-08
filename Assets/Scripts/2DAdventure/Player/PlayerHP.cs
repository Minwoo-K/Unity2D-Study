using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private int max = 3;
    [SerializeField]
    private int current;

    private void Awake()
    {
        current = max;
    }

    public void DecreaseHP()
    {
        current --;

        if ( current == 0 )
        {
            Debug.Log("Player Dead");
        }
    }
}
