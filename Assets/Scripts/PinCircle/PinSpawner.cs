using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PinPrefab; // The Registered Pin Prefab
    [SerializeField]
    private Transform target; // The Target in the Game
    [SerializeField]
    private int throwablePins; // The Number of Throwable Pins
    [SerializeField]
    private int stuckPins; // The Number of Stuck Pins

    
    private Vector3 firstSpawningPosition = Vector3.down * 2; // First Pin's Spawning Position
    private float interval = 1.0f; // The Interval Between Throwable Pins
    private float targetRadius = 0.5f;
    private float pinLength = 2f;

    private void Start()
    {
        SpawnThrowablePin(throwablePins);
        SpawnStuckPin(stuckPins);
    }

    public void SpawnThrowablePin(int count)
    {
        for ( int i = 0; i < count; i++ )
        {
            GameObject pin = Instantiate(PinPrefab);
            pin.transform.position = firstSpawningPosition + Vector3.down * interval * i;
        }
    }

    public void SpawnStuckPin(int count)
    {
        for ( int i = 0; i < count; i++ )
        {
            float angle = 360 / count * i;
            GameObject pin = Instantiate(PinPrefab);
            pin.transform.position = Utils.GetPositionFromAngle(angle, targetRadius + pinLength) + target.transform.position;
            pin.transform.parent = target;
            pin.transform.rotation = Quaternion.Euler(0, 0, angle);
            pin.GetComponent<Pin>().ActivateBar();
        }
    }
}
