using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField]
        private GameObject projectile;
        [SerializeField]
        private Transform spawningPoint;

        public void FireProjectile(int direction)
        {
            GameObject clone = Instantiate(projectile, spawningPoint.position, Quaternion.identity);
            clone.GetComponent<PlayerProjectile>().Setup(direction);
        }
    }
}
