using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waveio
{
    public class PlayerController : MonoBehaviour
    {
        private Move2D move;

        private void Start()
        {
            move = GetComponent<Move2D>();
        }

        void FixedUpdate()
        {
            move.MoveInX();

            if ( Input.GetMouseButton(0) )
            { 
                move.MoveInY(); 
            }
        }
    }
}
