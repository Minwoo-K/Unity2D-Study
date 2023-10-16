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
        private Transform firstTile;   // The First tile
        [SerializeField]
        private Transform currentTile;  // Current tile's Transform as a reference
        [SerializeField]
        private ZigZagManager zigzagManager; // To Track scoring in tiles

        private List<Tile> tilePool = new List<Tile>();
        private int index = 100;        // The number of tiles to make
        private Vector3 firstTilePosition;

        private void Start()
        {
            // Save the first Tile's position
            firstTilePosition = firstTile.position;
            // Spawn tiles for index times
            for ( int i = 0; i < index; i++ )
            {
                SpawnTile();
            }
        }

        private void SpawnTile()
        {
            // Spawn a tile on the scene
            GameObject clone = Instantiate(tilePrefab);
            // Put the tile under the given gameobject(TileSpawner)
            clone.transform.SetParent(transform);
            // Fetch the Tile component
            Tile tile = clone.GetComponent<Tile>();
            // Set up Tile component
            tile.SetUp(this, zigzagManager);
            // Put the Tile into the Pool
            tilePool.Add(tile);
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
            if ( currentTile != null )
            {
                tile.position = currentTile.position + direction;
            }
            else
            {
                tile.position = firstTilePosition + direction;
            }
            
            
            // Decide whether to spawn the Item or not
            random = Random.Range(0, 100);
            // Item Spawning Rate - 20%
            if (random < 20)
            {
                // Fetch Item component
                Item item = tile.GetChild(1).GetComponent<Item>();
                // Activate the Item object
                item.gameObject.SetActive(true);
                // Set up the Item object
                item.Setup(zigzagManager);
            }
            // Set the current tile to the given tile for the next tile
            
            currentTile = tile;
        }

        public void Clear()
        {
            currentTile = null;
            // Bring back the first tile
            firstTile.position = firstTilePosition;
            // Activate the First Tile as it was deactivated in its Tile component
            firstTile.gameObject.SetActive(true);
            // Destroy each Tile object in the Pool
            foreach ( Tile tile in tilePool )
            {
                Destroy(tile.gameObject);
            }
            // Clear the Pool
            tilePool.Clear();
        }
    }
}