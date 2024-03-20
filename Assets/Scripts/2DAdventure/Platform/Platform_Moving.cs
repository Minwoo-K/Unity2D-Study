using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Moving : MonoBehaviour
{
    [SerializeField]
    private Transform target;       // The Target to move
    [SerializeField]
    private Transform[] stations;   // Stations where the Target stops
    [SerializeField]
    private float waitingTime;      // Waiting time when the Target reaches each station
    [SerializeField]
    private float timeOffset;       // MovingTime = Distance x timeOffset

    private int index = 0;
    private bool indexIncrease = true;

    private void Awake()
    {
        target.position = stations[index].position;
        index++;

        StartCoroutine(MovingInLoop());
    }

    private IEnumerator MovingInLoop()
    {
        while ( true )
        {
            yield return new WaitForSeconds(waitingTime);

            yield return StartCoroutine(MoveAToB(target.position, stations[index].position));

            if (index == stations.Length - 1) indexIncrease = false;
            else if (index == 0) indexIncrease = true;

            index = indexIncrease ? ++index : --index;
        }
    }

    private IEnumerator MoveAToB(Vector3 A, Vector3 B)
    {
        float distance = Vector3.Distance(A, B);
        float movingTime = distance * timeOffset;
        float percent = 0;

        while ( percent < 1 )
        {
            percent += Time.deltaTime / movingTime;
            target.position = Vector3.Lerp(A, B, percent);

            yield return null;
        }
    }
}
