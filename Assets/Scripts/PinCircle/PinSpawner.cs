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
    [SerializeField]
    private GameObject textPinIndexPrefab;
    [SerializeField]
    private Transform indexParent;

    private List<Pin> ThrowablePins = new List<Pin>();
    private Vector3 firstSpawningPosition = Vector3.down * 2; // First Pin's Spawning Position
    private float interval = 1.0f;  // The Interval Between Throwable Pins
    private float targetRadius = 0.5f;  // Target's Radius
    private float pinLength = 2f;   // The Pin's Length
    private float ThrowingAngle = 270; // The Angle when a Pin is thrown

    private void Start()
    {
        for ( int i = 0; i < NumberOfThrowables; i++ )
        {
            SpawnThrowablePin(firstSpawningPosition + Vector3.down * interval * i, NumberOfStuck+1+i);
        }

        for ( int i = 0; i < NumberOfStuck; i++ )
        {
            SpawnStuckPin(360 / NumberOfStuck * i, i+1); // The Angle is based on the number of pins
        }
    }

    public Pin SpawnPin(Vector3 position)
    {
        GameObject clone = Instantiate(PinPrefab); // Spawn a Pin
        clone.transform.position = position; // Set its position to the given parameter
        Pin pin = clone.GetComponent<Pin>(); // Fetch the Pin component to return

        return pin;
    }

    public void SpawnThrowablePin(Vector3 position, int index)
    {
        Pin pin = SpawnPin(position); // Spawn a Pin and Get Pin Component
        pin.GetComponent<Pin>().ActivateBar(false); // Deactivate the Bar
        ThrowablePins.Add(pin); // Store the Pin into the List to handle
        SpawnIndexUI(pin.transform, index);
    }

    public void SpawnStuckPin(float angle, int index)
    {
        Pin pin = SpawnPin(Utils.GetPositionFromAngle(angle, targetRadius + pinLength) + Target.transform.position);
        // Instantiate the Pin. The given Pin's Position is based on position of the Target + pinLength
        pin.transform.parent = Target; // Put the Pin under the Target to let it rotate along
        pin.transform.rotation = Quaternion.Euler(0, 0, angle); // Rotate the Pin to get the Bar properly connected
        pin.GetComponent<Pin>().ActivateBar(true); // Activate the Bar when stuck to the Target
        SpawnIndexUI(pin.transform, index);
    }

    public void ThrowPin()
    {
        if (ThrowablePins.Count == 0) return; // if No Pin is left in the List, do nothing.

        Pin pin = ThrowablePins[0]; // Grab the First Pin in the Order.
        pin.transform.position = Utils.GetPositionFromAngle(ThrowingAngle, targetRadius + pinLength) + Target.transform.position;
        // The given Pin's Position is based on position of the Target + pinLength
        pin.transform.parent = Target; // Put the Pin under the Target to let it rotate along
        pin.transform.rotation = Quaternion.Euler(0, 0, ThrowingAngle); // Rotate the Pin to get the Bar properly connected
        pin.GetComponent<Pin>().ActivateBar(true); // Activate the Bar when stuck to the Target

        ThrowablePins.Remove(pin); // Remove the thrown Pin from the List and rearrange the List

        StartCoroutine(MoveUpPins()); // Move Up all the Pins
    }

    public void SpawnIndexUI(Transform target, int index)
    {
        GameObject clone = Instantiate(textPinIndexPrefab);

        clone.transform.SetParent(indexParent);

        clone.transform.localScale = Vector3.one;

        clone.GetComponent<WorldToScreenPosition>().Setup(target);

        clone.GetComponent<TMPro.TextMeshProUGUI>().text = index.ToString();
    }

    public IEnumerator MoveUpPins()
    {
        float moveTime = 0.2f;

        //yield return new WaitForSeconds(moveTime);

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
