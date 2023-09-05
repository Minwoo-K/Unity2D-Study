using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject pinPrefab; // Pin Prefab
    [SerializeField]
    private Transform target; // The Target transform

    private Vector3 startPosition = Vector3.down * 2; // Throwable Pin Starting Position
    private float interval = 1.0f; // The interval between Throwable Pins
    private float radius = 0.5f; // The Target's radius
    private float barLength = 1.5f; // The Length of a Pin

    /// <summary>
    /// Set up a stage before starting
    /// </summary>
    /// <param name="throwablePins"> Number of Throwable Pins to spawn </param>
    /// <param name="stuckPins"> Number of Stuck Pins to spawn </param>
    public void Setup(int throwablePins, int stuckPins)
    {
        // Spawn Throwable Pins
        for ( int i = 0; i < throwablePins; i++ )
        {
            // Position Pins based on the interval value
            SpawnThrowablePin(startPosition + Vector3.down * interval * i);
        }

        for ( int i = 0; i < stuckPins; i++ )
        {
            float angle = 360 / stuckPins * i;
            SetPinStuckToTarget(angle);
        }
    }

    public void SpawnThrowablePin(Vector3 position)
    {
        // Instantiate a Pin object
        GameObject clone = Instantiate(pinPrefab);
        // Set its position to the given position
        clone.transform.position = position;
    }

    public void SetPinStuckToTarget(float angle)
    {
        // Instantiate a Pin object
        GameObject clone = Instantiate(pinPrefab);
        // Set its position based on the angle
        clone.transform.position = Utils.GetPositionFromAngle(angle, radius+barLength) + target.position;
        // Set its parent to the target so that they rotate together
        clone.transform.SetParent(target);
        // Rotate it to the angle to get the bar connected to the target
        clone.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
