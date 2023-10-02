using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waveio
{
    public class AreaSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] areaPrefabs;   // To register existing Area objects
        [SerializeField]
        private Transform player;           // To track player's position
        [SerializeField]
        private int startIndex = 2;         // Start with 2 Areas 
        [SerializeField]
        private float gapBtwnAreas = 30;    // Gap between Areas
        [SerializeField]
        private WaveioManager waveioManager;// To manage the game level

        private List<GameObject> spawnedAreas = new List<GameObject>(); // To save and discard areas once used up
        private int areaIndex = 0;          // To track the number of areas spawned

        private void Awake()
        {
            Reset();
        }

        private void Update()
        {
            if ( (int)player.position.y / gapBtwnAreas + 1 == areaIndex)
            {
                SpawnArea();
            }

            if (spawnedAreas.Count == 4)
            {
                DeleteArea();
            }
        }

        private void SpawnArea()
        {
            int random = Random.Range(0, areaPrefabs.Length);

            GameObject area = Instantiate(areaPrefabs[random]);

            area.transform.position = Vector3.up * areaIndex * gapBtwnAreas;

            spawnedAreas.Add(area);

            areaIndex++;

            // Every 5 area, the game level goes up
            if ( areaIndex % 3 == 0 )
            {
                waveioManager.LevelIncreased();
            }
        }

        private void DeleteArea()
        {
            GameObject area = spawnedAreas[0];

            Destroy(area);

            spawnedAreas.RemoveAt(0);
        }

        private void DeleteAllAreas()
        {
            while ( spawnedAreas.Count != 0 )
            {
                DeleteArea();
            }
        }

        public void Reset()
        {
            DeleteAllAreas();

            areaIndex = 0;

            for (int i = 0; i < startIndex; i++)
            {
                SpawnArea();
            }
        }
    }
}