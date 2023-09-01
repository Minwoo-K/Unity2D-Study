using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PinPrefab; // The Registered Pin Prefab
    [SerializeField]
    private int throwablePins; // The Number of Throwable Pins
    [SerializeField]
    private int stuckPins; // The Number of Stuck Pins

    private Vector3 firstSpawningPosition = Vector3.down * 2; // First Pin's Spawning Position
    private float interval = 1.0f; // The Interval Between Throwable Pins

    private void Start()
    {
        SpawnThrowablePin(throwablePins);
    }

    public void SpawnThrowablePin(int count)
    {
        for ( int i = 0; i < throwablePins; i++ )
        {
            GameObject pin = Instantiate(PinPrefab);
            pin.transform.position = firstSpawningPosition + Vector3.down * interval * i;
        }
    }

    public void SpawnStuckPin()
    {

    }
}
