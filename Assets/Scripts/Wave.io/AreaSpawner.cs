using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] areaPrefabs;
    [SerializeField]
    private float areaGap = 30;
    [SerializeField]
    private Transform player;

    private List<GameObject> areaSpawned = new List<GameObject>();
    private int numberOfArea = 0;
    private int startingNumberOfAreas = 2;

    private void Awake()
    {
        for (int i = 0; i < startingNumberOfAreas; i++)
            SpawnArea();
    }

    private void Update()
    {
        if ( (int)player.position.y / areaGap == numberOfArea - 1 )
        {
            SpawnArea();
        }

        if ( areaSpawned.Count == 3 )
        {
            DeleteUsedArea();
        }
    }

    private void SpawnArea()
    {
        int index = Random.Range(0, areaPrefabs.Length);

        GameObject area = Instantiate(areaPrefabs[index]);

        area.transform.position = Vector3.up * areaGap * numberOfArea;

        areaSpawned.Add(area);

        numberOfArea++;
    }

    private void DeleteUsedArea()
    {
        GameObject area = areaSpawned[0];
        
        Destroy(area);

        areaSpawned.RemoveAt(0);
    }
}
