using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject  projectilePrefab;
    [SerializeField]
    private Transform   spawningPoint;

    public void ShootProjectile(float direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, spawningPoint.position, Quaternion.identity);
        projectile.GetComponent<PlayerProjectile>().Spawned(direction);
    }
}
