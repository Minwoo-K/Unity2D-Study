using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    private Vector2 spawningForce = new Vector2(1, 7);
    [SerializeField]
    private float itemAliveTime = 5;

    private bool allowCollect = true;

    public abstract void UpdateItemTaken();

    public void Init()
    {
        StartCoroutine(SpawnItemProcess());
    }

    private IEnumerator SpawnItemProcess()
    {
        allowCollect = false;

        Rigidbody2D rigid2D = gameObject.AddComponent<Rigidbody2D>();
        rigid2D.freezeRotation = true;
        rigid2D.velocity = new Vector2(Random.Range(-spawningForce.x, spawningForce.x), spawningForce.y);

        while ( rigid2D.velocity.y > 0 )
        {
            yield return null;
        }

        allowCollect = true;
        GetComponent<Collider2D>().isTrigger = true;

        yield return new WaitForSeconds(itemAliveTime);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( allowCollect && collision.CompareTag("Player") )
        {
            UpdateItemTaken();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (allowCollect && collision.gameObject.CompareTag("Player"))
        {
            UpdateItemTaken();
            Destroy(gameObject);
        }
    }
}
