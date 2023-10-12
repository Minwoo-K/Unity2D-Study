using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class Item : MonoBehaviour
    {
        [SerializeField]
        private ZigZagManager zigzagManager;    // To Track scoring
        [SerializeField]
        private GameObject itemTakenEffect;     // The Particle Effect: ItemTakenEffect

        private float rotateSpeed = 50f;        // Rotation Speed
        private const int point = 3;            // The points the item is worth

        private void Awake()
        {
            // Turn the Prefab to a Game Object
            itemTakenEffect = Instantiate(itemTakenEffect);
            // Get it ready by deactivating it
            itemTakenEffect.SetActive(false);
        }

        private void Update()
        {
            transform.Rotate(new Vector3(1, 1, 0) * Time.deltaTime * rotateSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if ( other.gameObject.tag.Equals("Player") )
            {
                // Increase the score by the point
                zigzagManager.IncreaseScore(point);
                // Deactivate the item
                gameObject.SetActive(false);
                // Play the particle system by activating it
                itemTakenEffect.transform.position = transform.position;
                itemTakenEffect.SetActive(true);
            }
        }

        public void Setup(ZigZagManager zigzagManager)
        {
            this.zigzagManager = zigzagManager;
        }
    }
}
