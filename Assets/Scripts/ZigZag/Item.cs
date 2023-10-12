using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class Item : MonoBehaviour
    {
        [SerializeField]
        private ZigZagManager zigzagManager;    // To Track scoring

        private float rotateSpeed = 50f;        // Rotation Speed
        private const int point = 3;            // The points the item is worth

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
            }
        }

        public void Setup(ZigZagManager zigzagManager)
        {
            this.zigzagManager = zigzagManager;
        }
    }
}
