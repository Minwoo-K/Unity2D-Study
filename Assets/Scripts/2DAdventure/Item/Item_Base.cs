using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Base : MonoBehaviour
{
    [SerializeField]
    private Vector2 spawningForce = new Vector2(1, 7);
    [SerializeField]
    private float   disappearInSeconds = 3;  // Time that the item disappears in

    private bool    collectible = true;    // Whether to be collectible or not

    public abstract void UponTaken(GameObject player);

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
        GetComponent<Collider2D>().isTrigger = false;

        yield return new WaitForSeconds(disappearInSeconds);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collectible && collision.CompareTag("Player") )
        {
            UponTaken(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collectible && collision.gameObject.CompareTag("Player"))
        {
            UponTaken(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
