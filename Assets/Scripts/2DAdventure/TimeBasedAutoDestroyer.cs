using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBasedAutoDestroyer : MonoBehaviour
{
    [SerializeField]
    private float       theTime;    // After this time, the gameobject is auto-destroyed

    private void Awake()
    {
        Destroy(gameObject, theTime);
    }
}
