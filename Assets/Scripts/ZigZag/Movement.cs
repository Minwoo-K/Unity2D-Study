using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;

        private Vector3 moveDirection;
        private float limitY = 0.5f;


        public Vector3 MoveDirection => moveDirection;

        private void Awake()
        {
            moveDirection = Vector3.right;
        }

        private void FixedUpdate()
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            if ( transform.position.y < limitY )
            {
                Debug.Log("Game Over");
            }
        }

        public void ChangeDirection()
        {
            moveDirection = moveDirection == Vector3.right ? Vector3.forward : Vector3.right;
        }
    }
}
