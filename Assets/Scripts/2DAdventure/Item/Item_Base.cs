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
        collectible = false;

        var rigid = GetComponent<Rigidbody2D>();
        rigid.isKinematic = false;
        rigid.velocity = new Vector2((Random.Range(-spawningForce.x, spawningForce.x)), spawningForce.y);

        while ( rigid.velocity.y > 0 )
        {
            yield return null;
        }

        collectible = true;
        
    }
}
