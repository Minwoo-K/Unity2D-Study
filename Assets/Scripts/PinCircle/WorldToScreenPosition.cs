using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldToScreenPosition : MonoBehaviour
{
    [SerializeField]
    private Vector3 delta; // Distance to add
    [SerializeField]
    private Transform targetTransform; // Target Transform

    private RectTransform rectTransform; // The RectTransform of the object 

    public void Setup(Transform target)
    {
        // Set the Target Transform
        targetTransform = target;
        // Fetch RectTransform component
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        // When the TargetTransform becomes null, Destroy this object
        if ( targetTransform == null )
        {
            Destroy(gameObject);
            return;
        }
        // Because Objects exist in the world and UIs exist in the screen
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
        // Set the UI object's position to the screen position
        rectTransform.position = screenPosition + delta;
    }
}
