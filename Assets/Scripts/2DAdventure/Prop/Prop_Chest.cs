using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_Chest : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemList;

    // Only can 2 items get spawned
    private readonly int    numberOfSpawning = 2;
    private SpriteRenderer  spriteRenderer;
    private bool            collided = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            if ( collided ) return;
            SpawnItems();
        }
    }

    private void SpawnItems()
    {
        collided = true;

        for ( int i = 0; i < numberOfSpawning; i++ )
        {
            int random = Random.Range(0, itemList.Length);
            GameObject item = Instantiate(itemList[random], transform.position, Quaternion.identity);
            item.GetComponent<Item_Base>().OnSpawning();
        }

        StartCoroutine(FadeAwayInTime());
    }

    private IEnumerator FadeAwayInTime()
    {
        float fadingTime = 5f, percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / fadingTime;

            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(color.a, 0, percent);
            spriteRenderer.color = color;

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
