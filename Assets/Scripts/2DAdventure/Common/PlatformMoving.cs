using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure_2D
{
    public class PlatformMoving : MonoBehaviour
    {
        [SerializeField]
        private Transform target;           // The Target this platform moves towards
        [SerializeField]
        private Transform[] wayPoints;      // Available stations
        [SerializeField]
        private float waitTime;             // Waiting time each station
        [SerializeField]
        private float timeOffset;           // Moving Time = Distance x timeOffset

        private int wayPointsCount;         // Count of the wayPoints
        private int currentIndex = 0;       // Current Index to track which wayPoint is

        private void Awake()
        {
            // Set the first position
            target.position = wayPoints[currentIndex].position;
            // Set the Count of wayPoints
            wayPointsCount = wayPoints.Length;
            // Set to the next wayPoint
            currentIndex ++;
            // Call the function to move between all the wayPoints
            StartCoroutine(Process());
        }

        // Infinite loop to move between the wayPoints
        private IEnumerator Process()
        {
            while ( true )
            {
                yield return StartCoroutine(MoveAToB(transform.position, target.position));

                if ( currentIndex >= wayPointsCount - 1 ) currentIndex++;
                else                                      currentIndex = 0;

                yield return new WaitForSeconds(waitTime);
            }
        }

        private IEnumerator MoveAToB(Vector3 A, Vector3 B)
        {
            float percent = 0;
            float movingTime = Vector3.Distance(A, B) * timeOffset;

            while ( percent < 1 )
            {
                percent += Time.deltaTime / movingTime;
                transform.position = Vector3.Lerp(A, B, percent);

                yield return null;
            }
        }

        // When the player is on the platform, they need to move together
        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.transform.SetParent(transform);
        }
        // When the player is off the platform, they no longer move together
        private void OnCollisionExit2D(Collision2D collision)
        {
            collision.transform.SetParent(null);
        }
    }
}


