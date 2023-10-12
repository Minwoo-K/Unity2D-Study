using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class TileSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject tilePrefab;  // Tile Prefab
        [SerializeField]
        private Transform currentTile;  // Current tile's Transform as a reference
        [SerializeField]
        private ZigZagManager zigzagManager; // To Track scoring in tiles

        private int index = 100;        // The number of tiles to make

        private void Start()
        {
            // Spawn tiles for index times
            for ( int i = 0; i < index; i++ )
            {
                SpawnTile();
            }
        }

        private void SpawnTile()
        {
            // Spawn a tile on the scene
            GameObject tile = Instantiate(tilePrefab);
            // Put the tile under the given gameobject(TileSpawner)
            tile.transform.SetParent(transform);
            // Set up Tile component
            tile.GetComponent<Tile>().SetUp(this, zigzagManager);
            // Decide whether to spawn the Item or not
            int random = Random.Range(0, 100);
            // Item Spawning Rate - 20%
            if ( random < 20 ) 
            {
                // Fetch Item component
                Item item = tile.transform.GetChild(1).GetComponent<Item>();
                // Activate the Item object
                item.gameObject.SetActive(true);
                // Set up the Item object
                item.Setup(zigzagManager);
            }
            // Position the tile properly based on the current(last) tile
            PositionTile(tile.transform);
        }

        public void PositionTile(Transform tile)
        {
            // Get a Random number either 0 or 1 (50%)
            int random = Random.Range(0, 2);
            // If 0, position the tile on the left(forward) side of the current tile, if 1, right side.
            Vector3 direction = random == 0 ? Vector3.forward : Vector3.right;
            // Position the tile with the direction
            tile.position = currentTile.position + direction;
            // Set the current tile to the given tile for the next tile
            currentTile = tile;
        }
    }
}