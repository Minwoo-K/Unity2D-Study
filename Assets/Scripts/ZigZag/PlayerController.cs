using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private ZigZagManager zigzagManager;

        private Movement movement;      // Movement component
        private float limitY = 0.8f;    // Limit value in Y axis

        private void Awake()
        {
            // Fetch Movement component
            movement = GetComponent<Movement>();
        }

        private IEnumerator Start()
        {
            while ( true )
            {
                // When the game starts,
                if ( zigzagManager.IsGameStart == true )
                {
                    // Initialize the direction to start moving
                    movement.ChangeDirection();

                    yield break;
                }

                yield return null;
            }
        }

        private void Update()
        {
            // If Game Over, no input allowed
            if ( zigzagManager.IsGameOver == true ) return;

            // If the object goes below this in Y axis, Game Over
            if ( transform.position.y < limitY )
            {
                zigzagManager.GameOver();
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
