using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class Tile : MonoBehaviour
    {
        [SerializeField]
        private float fallingTime;          // Falling time once the player passes the tile
        [SerializeField]
        private TileSpawner tileSpawner;    // To relocate the tile once used
        
        private Rigidbody rigid;            // Rigidbody attached to the object
        private ZigZagManager zigzagManager;// To track scoring
        private const int point = 1;        // The point a Tile is worth

        private void Awake()
        {
            // Fetch Rigidbody
            rigid = GetComponent<Rigidbody>();
        }

        private void OnCollisionExit(Collision collision)
        {
            // Once the Player has passed
            if ( collision.gameObject.tag.Equals("Player") )
            {
                if ( zigzagManager != null )
                {
                    // Player ears a point when passing a tile
                    zigzagManager.IncreaseScore(point);
                }
                // The tile starts falling down and gets relocated(respawned)
                StartCoroutine(FallDownAndRespawn());
            }
        }

        private IEnumerator FallDownAndRespawn()
        {
            // Wait for 0.1 sec to make sure the player has passed
            yield return new WaitForSeconds(0.1f);
            // To make the tile fall
            rigid.isKinematic = false;
            // Tile to fall for the set falling time
            yield return new WaitForSeconds(fallingTime);
            // Stop falling after the time to avoid further position calculation
            rigid.isKinematic = true;

            // If TileSpawner has been set up,
            if ( tileSpawner != null )
            {
                // Relocate the tile
                tileSpawner.PositionTile(transform);
            }
            else // If No TileSpawner set up, deactivate the object(for the first tile and starting ground)
            {
                gameObject.SetActive(false);
            }
        }

        public void SetUp(TileSpawner tileSpawner, ZigZagManager zigzagManager)
        {
            this.tileSpawner = tileSpawner;

            this.zigzagManager = zigzagManager;
        }
    }
}
