using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FollowPath_State { Idle = 0, Move }

public class FollowPath : MonoBehaviour
{
    // Serialize Fields
    [SerializeField]
    private Transform   target;     // To Specify the transform object
    [SerializeField]
    private Transform[] stations;   // Stations where the platform stays for the given waiting time
    [SerializeField]
    private float       waitingTime;      // The Waiting Time once the platform reaches a station
    [SerializeField]
    private float       speedOffset;      // An offset value to set time of the platform moving one to another. The bigger the value, the slower

    // Private Variables
    private int         currentIndex;
    private bool        indexIncreasing;
    private int         direction;
    
    // Properties
    public FollowPath_State State { private set; get; }
    public int              Direction => direction;

    private void Awake()
    {
        currentIndex = 0;
        indexIncreasing = true;
        target.position = stations[currentIndex].position;

        StartCoroutine(MovingInLoop());
    }

    private IEnumerator MovingInLoop()
    {
        while (true)
        {
            if (currentIndex == 0) indexIncreasing = true;
            else if (currentIndex == stations.Length - 1) indexIncreasing = false;

            currentIndex = indexIncreasing ? ++currentIndex : --currentIndex;

            yield return StartCoroutine(MoveAToB(target.position, stations[currentIndex].position));

            yield return new WaitForSeconds(waitingTime);
        }
    }

    private IEnumerator MoveAToB(Vector3 A, Vector3 B)
    {
        float distance = Vector3.Distance(A, B);
        float movingTime = distance * speedOffset;
        float percent = 0;

        SetDirection(A.x, B.x);
        State = FollowPath_State.Move;

        while (percent < 1)
        {
            percent += Time.deltaTime / movingTime;

            Vector3 position = Vector3.Lerp(A, B, percent);
            target.position = position;

            yield return null;
        }

        State = FollowPath_State.Idle;
    }

    private void SetDirection(float start, float end)
    {
        if ( end - start != 0 ) direction = (int)Mathf.Sign(end - start);
        else                    direction = 0;
    }

    public void Stop()
    {
        StopAllCoroutines();
    }
}
