using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class PlayerController : MonoBehaviour
    {
        private Movement movement;      // Movement component
        private float limitY = 0.5f;    // Limit value in Y axis

        private void Start()
        {
            // Fetch the Movement component attached to the object
            movement = GetComponent<Movement>();    
        }

        private void Update()
        {
            // If the object goes below this in Y axis, Game Over
            if ( transform.position.y < limitY )
            {
                Debug.Log("Game Over");
                return;
            }

            // Change the direction anytime left mouse button was pressed
            if ( Input.GetMouseButtonDown(0) )
            {
                movement.ChangeDirection();
            }
        }
    }
}
