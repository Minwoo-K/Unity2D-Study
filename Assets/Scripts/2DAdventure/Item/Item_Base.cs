using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Base : MonoBehaviour
{
    [SerializeField]
    private Vector2 spawningForce = new Vector2(1, 7);
    [SerializeField]
    private float   goneInSeconds;      // Time that the item disappears in

    private bool    collectible;        // Whether to be collectible or not



    public void OnSpawning()
    {
        StartCoroutine(SpawningProcess());
    }

    private IEnumerator SpawningProcess()
    {
        yield return null;
    }
}
