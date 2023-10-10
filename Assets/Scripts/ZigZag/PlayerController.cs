using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private ZigZagManager zigZagManager;    // ZigZag Manager

        private Movement movement;      // Movement component
        private float limitY = 0.5f;    // Limit value in Y axis

        private void Awake()
        {
            // Fetch the Movement component attached to the object
            movement = GetComponent<Movement>();
        }

        private IEnumerator Start()
        {
            while ( true )
            {
                if ( zigZagManager.GameStart == true )
                {
                    movement.ChangeDirection();

                    yield break;
                }

                yield return null;
            }
        }

        private void Update()
        {
            // If the object goes below this in Y axis, Game Over
            if (transform.position.y < limitY)
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
