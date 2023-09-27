using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyer : MonoBehaviour
{
    [SerializeField]
    private float destroyInSeconds;

    private void Awake()
    {
        Destroy(gameObject, destroyInSeconds);
    }
}
