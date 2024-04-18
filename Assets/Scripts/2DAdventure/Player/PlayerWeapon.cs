using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private PlayerStat playerStat;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform spawningPoint;

    // Item - Projectile
    [SerializeField]
    private int projectileCount = 0;
    private readonly int maxProjectile = 9;

    public int ProjectileCount => projectileCount;
    
    public void LoadProjectile()
    {
        projectileCount += 3;
        if ( projectileCount > maxProjectile ) projectileCount = maxProjectile;

        playerStat.ProjectileEarned(projectileCount);
    }

    public void FireProjectile(float direction)
    {
        if ( projectileCount == 0 ) return;

        GameObject clone = Instantiate(projectile, spawningPoint.position, Quaternion.identity);
        clone.GetComponent<Projectile>().Setup(direction);

        projectileCount--;

        playerStat.ProjectileEarned(projectileCount);
    }
}
