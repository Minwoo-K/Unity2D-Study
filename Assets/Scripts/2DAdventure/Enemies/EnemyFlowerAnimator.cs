using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlowerAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform spawnPoint;
    //private Vector3 direction;

    public void FireProjectile()
    {
        Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
    }
}
