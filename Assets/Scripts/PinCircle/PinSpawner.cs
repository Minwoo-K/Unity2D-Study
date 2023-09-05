using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PinPrefab; // The Registered Pin Prefab
    [SerializeField]
    private Transform Target; // The Target in the Game
    [SerializeField]
    private int NumberOfThrowables; // The Number of Throwable Pins
    [SerializeField]
    private int NumberOfStuck; // The Number of Stuck Pins

    private List<Pin> ThrowablePins = new List<Pin>();
    private Vector3 firstSpawningPosition = Vector3.down * 2; // First Pin's Spawning Position
    private float interval = 1.0f;  // The Interval Between Throwable Pins
    private float targetRadius = 0.5f;  // Target's Radius
    private float pinLength = 2f;   // The Pin's Length
    private float ThrowingAngle = 270; // The Angle when A Pin is thrown

    private void Start()
    {
        SpawnThrowablePin(NumberOfThrowables);
        SpawnStuckPin(NumberOfStuck);
    }

    // TO-DO
    // Split behaviours into Spawning A Pin and Throwing A Pin at the Target to reduce redundancy 

    public Pin SpawnPin(Vector3 position)
    {
        GameObject clone = Instantiate(PinPrefab);
        clone.transform.position = position;
        Pin pin = clone.GetComponent<Pin>();

        return pin;
    }

    public void SpawnThrowablePin(int count)
    {
        for ( int i = 0; i < count; i++ )
        {
            Pin pin = SpawnPin(firstSpawningPosition + Vector3.down * interval * i); // Spawn a Pin and Get Pin Component
            pin.GetComponent<Pin>().ActivateBar(false); // Deactivate the Bar
            ThrowablePins.Add(pin); // Store the Pin into the List to handle
        }
    }

    public void SpawnStuckPin(int count)
    {
        for ( int i = 0; i < count; i++ )
        {
            float angle = 360 / count * i; // The Angle is based on the number of pins
            Pin pin = SpawnPin(Utils.GetPositionFromAngle(angle, targetRadius + pinLength) + Target.transform.position);
            // Instantiate the Pin. The given Pin's Position is based on position of the Target + pinLength
            pin.transform.parent = Target; // Put the Pin under the Target to let it rotate along
            pin.transform.rotation = Quaternion.Euler(0, 0, angle); // Rotate the Pin to get the Bar properly connected
            pin.GetComponent<Pin>().ActivateBar(true); // Activate the Bar when stuck to the Target
        }
    }

    public void ThrowPin()
    {
        Pin pin = ThrowablePins[0];
        pin.transform.position = Utils.GetPositionFromAngle(ThrowingAngle, targetRadius + pinLength) + Target.transform.position;
        // The given Pin's Position is based on position of the Target + pinLength
        pin.transform.parent = Target; // Put the Pin under the Target to let it rotate along
        pin.transform.rotation = Quaternion.Euler(0, 0, ThrowingAngle); // Rotate the Pin to get the Bar properly connected
        pin.GetComponent<Pin>().ActivateBar(true); // Activate the Bar when stuck to the Target

        ThrowablePins.Remove(pin);

        StartCoroutine(MoveUpPins());
    }

    public IEnumerator MoveUpPins()
    {
        float moveTime = 0.2f;

        for ( int i = 0; i < ThrowablePins.Count; i++ )
        {
            Pin pin = ThrowablePins[i];
            Vector3 start = pin.transform.position;
            Vector3 end = pin.transform.position + Vector3.up * interval;

            float current = 0;
            float percent = 0;

            while ( percent < 1 )
            {
                current += Time.deltaTime;
                percent = current / moveTime;

                pin.transform.position = Vector3.Lerp(start, end, percent);

                yield return null;
            }
        }
    }
}
