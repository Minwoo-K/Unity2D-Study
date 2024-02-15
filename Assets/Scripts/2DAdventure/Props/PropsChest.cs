using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PropsChest : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] itemPrefabs;
        [SerializeField]
        private Sprite openChestImage;
        [SerializeField]
        private int itemCount;

        private SpriteRenderer spriteRenderer;
        private bool isChestOpen = false;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isChestOpen == false && collision.CompareTag("Player"))
            {
                isChestOpen = true;

                spriteRenderer.sprite = openChestImage;

                StartCoroutine(OpenChest());
            }
        }

        private IEnumerator OpenChest()
        {
            int count = itemCount;

            while (count > 0)
            {
                int index = Random.Range(0, itemPrefabs.Length);
                GameObject clone = Instantiate(itemPrefabs[index], transform.position, Quaternion.identity);
                clone.GetComponent<ItemBase>().Init();

                yield return new WaitForSeconds(Random.Range(0.01f, 0.1f));

                count--;
            }

            float fadeTime = 2;
            StartCoroutine(FadeEffect.FadeOn(spriteRenderer, 1,  0, fadeTime));
            Destroy(gameObject, fadeTime);
        }
    }
}
