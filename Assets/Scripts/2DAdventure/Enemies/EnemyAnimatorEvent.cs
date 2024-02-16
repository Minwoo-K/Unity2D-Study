using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    public void OnDie()
    {
        Destroy(parent);
    }
}
