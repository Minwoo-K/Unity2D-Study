using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag
{
    public class TileSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject tilePrefab;
        [SerializeField]
        private Transform currentTile;
        [SerializeField]
        private int initialTileNumber = 10;

        private void Start()
        {
            for (int i = 0; i < initialTileNumber; i++)
            {
                CreateTile();
            }
        }

        private void CreateTile()
        {
            // Spawn the tile in the scene
            GameObject tile = Instantiate(tilePrefab, transform);
            // Put the tile under the TileSpawner object
            tile.transform.SetParent(transform);
            // Properly spawn the tile
            SpawnTile(tile.transform);
        }

        private void SpawnTile(Transform tile)
        {
            // Randomize either 0 or 1
            int random = Random.Range(0, 2);
            // If 0, tile is generated on the LEFT side of the current tile and if 1, on its right side.
            Vector3 direction = random == 0 ? Vector3.forward : Vector3.right;
            // Put the tile accordingly
            tile.position = currentTile.transform.position + direction;
            // Set the generated tile as the current tile to reference for next time generating a tile
            currentTile = tile;
        }
    }
}
