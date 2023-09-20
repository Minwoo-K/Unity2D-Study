using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waveio
{
    public class Mover : MonoBehaviour
    {
        [Header("X axis")]
        [SerializeField]
        private float xSpeed;
        [SerializeField]
        private float xRange;

        [Header("Y axis")]
        [SerializeField]
        private float ySpeed;
        [SerializeField]
        private float yRange;

        private Vector3 startPosition;

        private void Start()
        {
            startPosition = transform.position;
        }

        void Update()
        {
            float x = startPosition.x + xRange * Mathf.Sin(xSpeed * Time.time);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            float y = startPosition.y + yRange * Mathf.Sin(ySpeed * Time.time);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
    }
}
