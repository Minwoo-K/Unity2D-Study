using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class Item : MonoBehaviour
    {
        [SerializeField]
        private ZigZagManager zigZagManager;
        [SerializeField]
        private GameObject itemTakenEffect;

        private float rotateSpeed = 10f;

        private void Update()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if ( other.gameObject.tag.Equals("Player") )
            {
                itemTakenEffect.SetActive(true);

                zigZagManager.IncreaseScore(3);
            }
        }
    }
}
