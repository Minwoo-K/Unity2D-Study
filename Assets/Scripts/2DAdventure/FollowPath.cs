using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    // Serialize Fields
    [SerializeField]
    private Transform[] stations;     // Stations where the platform stays for the given waiting time
    [SerializeField]
    private float waitingTime;    // The Waiting Time once the platform reaches a station
    [SerializeField]
    private float speedOffset;    // An offset value to set time of the platform moving one to another. The bigger the value, the slower

    // Private Variables
    private int currentIndex;
    private bool indexIncreasing;
    private int direction;

    // Properties
    public int Direction => direction;

    public void Awake()
    {
        currentIndex = 0;
        indexIncreasing = true;
        direction = 0;
        transform.position = stations[currentIndex].position;

        StartCoroutine(MovingInLoop());
    }

    private IEnumerator MovingInLoop()
    {
        while (true)
        {
            if (currentIndex == 0) indexIncreasing = true;
            else if (currentIndex == stations.Length - 1) indexIncreasing = false;

            currentIndex = indexIncreasing ? ++currentIndex : --currentIndex;

            yield return StartCoroutine(MoveAToB(transform.position, stations[currentIndex].position));

            yield return new WaitForSeconds(waitingTime);
        }
    }

    private IEnumerator MoveAToB(Vector3 A, Vector3 B)
    {
        float distance = Vector3.Distance(A, B);
        float movingTime = distance * speedOffset;
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime / movingTime;

            Vector3 position = Vector3.Lerp(A, B, percent);
            transform.position = position;

            yield return null;
        }
    }

    private void SetDirection(float start, float end)
    {
        if ( end - start != 0 ) direction = (int)Mathf.Sign(end-start);
        else                    direction = 0;
    }
}
