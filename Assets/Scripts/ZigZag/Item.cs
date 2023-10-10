using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class Item : MonoBehaviour
    {
        [SerializeField]
        private GameObject itemTakenEffect;     // Particle Effect when the item was taken

        private ZigZagManager zigZagManager;    // To score for the item
        private float rotateSpeed = 50f;        // Rotating Speed for the item

        public void Setup(ZigZagManager zigZagManager)
        {
            this.zigZagManager = zigZagManager;
            // Transfer the prefab to the actual object
            itemTakenEffect = Instantiate(itemTakenEffect, transform.position, Quaternion.identity);
            itemTakenEffect.SetActive(false);
        }

        private void Update()
        {
            // Rotation feature
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            // When taken by the player
            if ( other.gameObject.tag.Equals("Player") )
            {
                // Move the particle effect to which this item was taken
                itemTakenEffect.transform.position = transform.position;
                // The ItemTakenEffect script will play the particle effect
                itemTakenEffect.SetActive(true);
                // Score for 3 points
                zigZagManager.IncreaseScore(3);
                // Make the Item object disappear
                gameObject.SetActive(false);
            }
        }
    }
}
