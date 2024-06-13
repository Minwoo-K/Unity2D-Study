using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Base : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private Vector2     spawningForce;
    private bool        takeable = true;
    private float       timeTillTakeable = 1f;
    private float       stayingTimeAfterSpawned = 5f;

    public void Setup()
    {
        rigid2D = gameObject.AddComponent<Rigidbody2D>();
        float x = Random.Range(-1f, 1f);
        spawningForce = new Vector2(x, 8f);

        ItemSpawned();
    }

    public abstract void UpdateCollision(GameObject player);

    private void ItemSpawned()
    {
        takeable = false;
        rigid2D.isKinematic = false;
        rigid2D.velocity = spawningForce;

        StartCoroutine(WaitForTakeable());

        Destroy(gameObject, stayingTimeAfterSpawned);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( takeable == false ) return;

        if ( collision.CompareTag("Player") )
        {
            UpdateCollision(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (takeable == false) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            UpdateCollision(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitForTakeable()
    {
        yield return new WaitForSeconds(timeTillTakeable);

        takeable = true;
        GetComponent<Collider2D>().isTrigger = false;
    }
}
