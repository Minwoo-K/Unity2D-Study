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
        private float limitY = 0.5f;    // Limit value in Y axis

        private void Awake()
        {
            movement = GetComponent<Movement>();
        }

        private IEnumerator Start()
        {
            while ( true )
            {
                if ( zigzagManager.gameStart == true )
                {
                    movement.ChangeDirection();

                    yield break;
                }

                yield return null;
            }
        }

        private void Update()
        {
            // If the game hasn't started, no input allowed
            //if (zigzagManager.gameStart == false) return;

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
