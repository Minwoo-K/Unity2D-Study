using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;

        private Vector3 direction;

        private void Start()
        {
            direction = Vector3.forward;
        }

        private void Update()
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        public void ChangeDirection()
        {
            direction = direction == Vector3.forward ? Vector3.right : Vector3.forward;
        }
    }
}
