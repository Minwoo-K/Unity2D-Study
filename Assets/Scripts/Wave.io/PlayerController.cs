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
        private GameObject playerCrashEffect;
        [SerializeField]
        private GameObject itemTakenEffect;

        private Vector3 startPosition;
        private Move2D move;
        private Data.WaveioDatum currentLevelData;

        private void Start()
        {
            startPosition = transform.position;
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
                Instantiate(itemTakenEffect, collision.transform.position, Quaternion.identity);

                waveioManager.ScoreIncreased();

                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Obstacle")
            {
                Instantiate(playerCrashEffect, transform.position, Quaternion.identity);

                CameraShakeEffect.Instance.ShakeCamera(0.1f, 0.5f);

                GetComponent<Rigidbody2D>().isKinematic = true;

                waveioManager.GameOver();
            }
        }

        public void SetLevelTo(Data.WaveioDatum levelData)
        {
            currentLevelData = levelData;

            move.ChangeSpeed(currentLevelData.playerXSpeed, currentLevelData.playerYSpeed);   
        }

        public void Reset()
        {
            transform.position = startPosition;

            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
