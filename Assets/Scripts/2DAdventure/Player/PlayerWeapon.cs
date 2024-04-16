using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform spawningPoint;

    public void FireProjectile(float direction)
    {
        GameObject clone = Instantiate(projectile, spawningPoint.position, Quaternion.identity);
        clone.GetComponent<Projectile>().Setup(direction);
    }
}
