using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public abstract class PlatformBase : MonoBehaviour
    {
        public bool IsHit { protected set; get; } = false;

        public abstract void UpdateCollision(GameObject other);
    }
}
