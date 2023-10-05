using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;    // Move Speed of the game object

        private Vector3 direction = Vector3.zero;  // Direction of the game object

        private void Start()
        {

        }

        private void Update()
        {
            // Move the gameObject
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        // A method to change direction.
        public void ChangeDirection()
        {
            direction = direction == Vector3.forward ? Vector3.right : Vector3.forward;
        }
    }
}
