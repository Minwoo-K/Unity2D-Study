using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform spawningPoint;

    // Item - Projectile
    [SerializeField]
    private int projectileCount;
    private readonly int maxProjectile = 9;
    
    public void LoadProjectile()
    {
        projectileCount += 3;
        if ( projectileCount > maxProjectile ) projectileCount = maxProjectile;
    }

    public void FireProjectile(float direction)
    {
        if ( projectileCount == 0 ) return;

        GameObject clone = Instantiate(projectile, spawningPoint.position, Quaternion.identity);
        clone.GetComponent<Projectile>().Setup(direction);

        projectileCount--;
    }
}
