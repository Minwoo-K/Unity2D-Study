using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class PlayerController : MonoBehaviour
    {
        private Movement movement;

        private void Start()
        {
            movement = GetComponent<Movement>();
        }

        private void Update()
        {
            if ( Input.GetMouseButtonDown(0) )
            {
                movement.ChangeDirection();
            }
        }
    }
}