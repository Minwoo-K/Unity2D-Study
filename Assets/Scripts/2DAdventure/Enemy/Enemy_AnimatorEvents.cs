using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AnimatorEvents : MonoBehaviour
{
    [SerializeField]
    private GameObject parentObject;

    public void OnDead()
    {
        Destroy(parentObject);
    }
}
