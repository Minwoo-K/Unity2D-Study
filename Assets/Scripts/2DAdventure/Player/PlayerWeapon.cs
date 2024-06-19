using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject  projectilePrefab;
    [SerializeField]
    private Transform   spawningPoint;
    [SerializeField]
    private UI_Controller ui_controller;

    private readonly int maxProjectileCount = 9;
    [SerializeField]
    private int          projectileCount = 0;

    public void LoadProjectile()
    {
        projectileCount += 3;
        if (projectileCount >= maxProjectileCount) projectileCount = maxProjectileCount;

        ui_controller.UpdateProjectile(projectileCount);
    }

    public void ShootProjectile(float direction)
    {
        if ( projectileCount <= 0 ) return;

        GameObject projectile = Instantiate(projectilePrefab, spawningPoint.position, Quaternion.identity);
        projectile.GetComponent<PlayerProjectile>().Spawned(direction);
        projectileCount--;

        ui_controller.UpdateProjectile(projectileCount);
    }
}
