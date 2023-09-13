using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float degree;

    private float delta = 50;

    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(degree), Mathf.Cos(degree), 0) * delta * Time.deltaTime;
    }
}
