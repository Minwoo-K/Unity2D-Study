using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waveio
{
    public class Move2D : MonoBehaviour
    {
        [Header("Horizontal(X axis) Movement")]
        [SerializeField]
        private float xSpeed;
        [SerializeField]
        private float xRange;

        [Header("Vertical(Y axis) Movement")]
        [SerializeField]
        private float ySpeed;

        private Vector3 startPosition;
        private Rigidbody2D rigid;

        private void Awake()
        {
            startPosition = transform.position;
            rigid = GetComponent<Rigidbody2D>();
        }

        public void MoveInX()
        {
            float x = startPosition.x + xRange * Mathf.Sin(xSpeed * Time.time);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        public void MoveInY()
        {
            rigid.AddForce(Vector3.up * ySpeed, ForceMode2D.Impulse);
        }
    }
}
