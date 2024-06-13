using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject  projectilePrefab;
    [SerializeField]
    private Transform   spawningPoint;

    private readonly int maxProjectileCount = 9;
    [SerializeField]
    private int          projectileCount = 0;

    public void LoadProjectile()
    {
        projectileCount += 3;
        if (projectileCount >= maxProjectileCount) projectileCount = maxProjectileCount;
    }

    public void ShootProjectile(float direction)
    {
        if ( projectileCount <= 0 ) return;

        GameObject projectile = Instantiate(projectilePrefab, spawningPoint.position, Quaternion.identity);
        projectile.GetComponent<PlayerProjectile>().Spawned(direction);
        projectileCount--;
    }
}
