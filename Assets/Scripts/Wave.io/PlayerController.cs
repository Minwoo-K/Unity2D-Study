using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waveio
{
    public class PlayerController : MonoBehaviour
    {
        private Movement2D movement;

        private void Start()
        {
            movement = GetComponent<Movement2D>();
        }

        private void FixedUpdate()
        {
            movement.MoveInX();

            if (Input.GetMouseButton(0))
            {
                movement.MoveInY();
            }
        }
    }
}
