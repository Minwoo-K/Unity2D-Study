using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{ 
    [CreateAssetMenu]
    public class StageData : ScriptableObject
    {
        [Header("Camera Constraints")]
        [SerializeField]
        private float cameraLimitMinX;      // Minimum Limit for Camera
        [SerializeField]
        private float cameraLimitMaxX;      // Maximum Limit for Camera

        [Header("Player Constraints")]
        [SerializeField]
        private float playerLimitMinX;      // Minimum Limit for the Player
        [SerializeField]
        private float playerLimitMaxX;      // Maximum Limit for the Player

        [Header("Map Constraints")]
        [SerializeField]
        private float mapLimitMinY;         // Minimum Map Limit in Y axis to figure out if the player falls off

        [Header("Start Positions Each Level")]
        [SerializeField]
        private Vector2 playerPosition;
        [SerializeField]
        private Vector2 cameraPosition;

        // Properties to each one above to let exterior access to them
        public float CameraLimitMinX  => cameraLimitMinX;
        public float CameraLimitMaxX  => cameraLimitMaxX;
        public float PlayerLimitMinX  => playerLimitMinX;
        public float PlayerLimitMaxX  => playerLimitMaxX;
        public float MapLimitMinY     => mapLimitMinY;
        public Vector2 PlayerPosition => playerPosition;
        public Vector2 CameraPosition => cameraPosition;
    }
}
