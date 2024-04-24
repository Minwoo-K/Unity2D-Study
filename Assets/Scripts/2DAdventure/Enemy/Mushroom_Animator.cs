using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Animator : MonoBehaviour
{
    [SerializeField]
    private GameObject parentObject;

    public void OnDead()
    {
        Destroy(parentObject);
    }
}
