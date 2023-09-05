using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject pinPrefab; // Pin Prefab
    [SerializeField]
    private Transform target; // The Target transform
    [SerializeField]
    private GameObject textIndexPrefab; // Index Text Prefab
    [SerializeField]
    private Transform indexParent; // The Parent of indexi

    private Vector3 startPosition = Vector3.down * 2; // Throwable Pin Starting Position
    private float interval = 1.0f; // The interval between Throwable Pins
    private float radius = 0.5f; // The Target's radius
    private float barLength = 1.5f; // The Length of a Pin
    private float throwingAngle = 270; // The angle of throwing a pin

    public List<Pin> throwablePins { private set; get; } = new List<Pin>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && throwablePins.Count != 0)
        {
            ThrowPin();
        }
    }

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
            SpawnThrowablePin(startPosition + Vector3.down * interval * i, stuckPins+1+i);
        }

        for ( int i = 0; i < stuckPins; i++ )
        {
            // Position Pins based on the angle
            float angle = 360 / stuckPins * i;
            SpawnStuckPin(angle, i+1);
        }
    }

    public void SpawnThrowablePin(Vector3 position, int index)
    {
        // Instantiate a Pin object
        GameObject clone = Instantiate(pinPrefab);
        // Set its position to the given position
        clone.transform.position = position;
        // Fetch Pin component to add to the List
        throwablePins.Add(clone.GetComponent<Pin>());
        // Show the Index UI
        SpawnIndexUI(clone.transform, index);
    }

    public void SpawnStuckPin(float angle, int index)
    {
        // Instantiate a Pin object
        GameObject clone = Instantiate(pinPrefab);
        // Get it to the Target
        SetPinStuckToTarget(clone.transform, angle);
        // Show the Index UI
        SpawnIndexUI(clone.transform, index);
    }

    public void SetPinStuckToTarget(Transform pin, float angle)
    {
        // Set its position based on the angle
        pin.transform.position = Utils.GetPositionFromAngle(angle, radius+barLength) + target.position;
        // Set its parent to the target so that they rotate together
        pin.transform.SetParent(target);
        // Rotate it to the angle to get the bar connected to the target
        pin.transform.rotation = Quaternion.Euler(0, 0, angle);
        // Call the function for when the Pin is in the target
        pin.GetComponent<Pin>().SetItStuck();
    }

    public void ThrowPin()
    {
        // Grab the first Pin in the List
        Pin pin = throwablePins[0];
        // Move the Pin to the target with the throwing angle
        SetPinStuckToTarget(pin.transform, throwingAngle);
        // Remove the Pin from the List to rearrange
        throwablePins.RemoveAt(0);

        // Move up all the existing Pins in the List
        for ( int i = 0; i < throwablePins.Count; i++ )
        {
            throwablePins[i].MoveUp(interval);
        }
    }

    public void SpawnIndexUI(Transform target, int index)
    {
        // Instantiate the UI object
        GameObject clone = Instantiate(textIndexPrefab);
        // Set its parent as the indexParent
        clone.transform.SetParent(indexParent);
        // Set up the WorldToScreenPosition component with the Target Transform
        clone.GetComponent<WorldToScreenPosition>().Setup(target);
        // Change the text as the given index value
        clone.GetComponent<TMPro.TextMeshProUGUI>().text = index.ToString();
    }
}
