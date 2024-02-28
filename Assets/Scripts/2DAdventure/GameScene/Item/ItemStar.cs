using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class ItemStar : ItemBase
    {
        [Tooltip("There are only 3 stars existing in a scene, indexed 0, 1, 2 respectfully")]
        [SerializeField][Range(0, 2)]
        private int starIndex;

        public int StarIndex => starIndex;

        public override void UpdateItemTaken(Transform transform)
        {
            transform.GetComponent<PlayerData>().GetStar(starIndex);
        }
    }
}

