using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animator : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    public void IsDead()
    {
        Destroy(parent);
    }
}
