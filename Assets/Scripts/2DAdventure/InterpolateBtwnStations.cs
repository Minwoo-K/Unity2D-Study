using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolateBtwnStations : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform[] stations;
    [SerializeField]
    private float timeSet;            // Time Setter to define how long it takes. The higher the longer time.
    [SerializeField]
    private float stayingTime;        // Time to stay once reached at a station

    private int index = 0;
    private bool indexIncreasing = true;

    public void StartInterpolation()
    {
        StartCoroutine(MoveInLoop());
    }

    private IEnumerator MoveInLoop()
    {
        target.position = stations[index].position;

        while (true)
        {
            index = indexIncreasing ? ++index : --index;

            if (index + 1 == stations.Length) indexIncreasing = false;
            else if (index == 0) indexIncreasing = true;

            yield return StartCoroutine(MoveAToB(target.position, stations[index].position));
        }
    }

    private IEnumerator MoveAToB(Vector3 A, Vector3 B)
    {
        float distance = Vector3.Distance(A, B);
        float movingTime = distance * timeSet; // Time = Distance * TimeSetter. If distance 5, if timeSet is 2, it takes 10s to move

        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime / movingTime;

            target.position = Vector3.Lerp(A, B, percent);

            yield return null;
        }

        yield return new WaitForSeconds(stayingTime);
    }

}
