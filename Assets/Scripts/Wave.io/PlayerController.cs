using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waveio
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private WaveioManager waveioManager;
        [SerializeField]
        private CameraController cameraController;

        private Move2D move;

        private void Start()
        {
            move = GetComponent<Move2D>();
        }

        void FixedUpdate()
        {
            if ( waveioManager.gameOver == true )
                return;

            move.MoveInX();

            if ( Input.GetMouseButton(0) )
            { 
                move.MoveInY(); 
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ( collision.gameObject.tag == "Item")
            {
                waveioManager.ScoreIncreased();

                cameraController.ChangeBackgroundColor();

                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Obstacle")
            {
                Destroy(GetComponent<Rigidbody2D>());

                waveioManager.GameOver();
            }
        }
    }
}
