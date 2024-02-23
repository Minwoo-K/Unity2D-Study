using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class TileBroke : TileBase
    {
        [Header("TileBroke Component")]
        [SerializeField]
        private GameObject particle;

        public override void UpdateCollsion()
        {
            // Overriden/Inherited function call
            base.UpdateCollsion();
            // Spawn the Particle effect
            Instantiate(particle, transform.position, Quaternion.identity);
            // Delete the Tile object
            Destroy(gameObject);
        }
    }
}
