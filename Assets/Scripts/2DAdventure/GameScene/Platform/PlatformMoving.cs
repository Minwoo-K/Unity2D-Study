using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PlatformMoving : MonoBehaviour
    {
        [SerializeField]
        private Transform platform;         // The Platform currently moving

        // When the player is on the platform, they need to move together
        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.transform.SetParent(platform);
        }
        // When the player is off the platform, they no longer move together
        private void OnCollisionExit2D(Collision2D collision)
        {
            collision.transform.SetParent(null);
        }
    }
}


