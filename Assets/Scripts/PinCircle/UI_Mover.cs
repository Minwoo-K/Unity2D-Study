using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Mover : MonoBehaviour
{
    private Action theEventAfter = null; // Define an Action type for an event after clicking a button
    private RectTransform rectTransform;
    private float moveTime = 1.0f;
    private bool isMoving = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void StartMoving(Action action, Vector3 end)
    {
        if ( isMoving != true )
        {
            //StopCoroutine("MoveTo");

            theEventAfter -= action;
            theEventAfter += action;

            StartCoroutine(MoveTo(action, end));
        }
    }

    private IEnumerator MoveTo(Action action, Vector3 end)
    {
        float current = 0;
        float percent = 0;
        Vector3 start = rectTransform.anchoredPosition;

        isMoving = true;

        while ( percent < 1 )
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            rectTransform.anchoredPosition = Vector3.Lerp(start, end, percent);

            yield return null;
        }

        isMoving = false;

        theEventAfter.Invoke();

        theEventAfter -= action;
    }
}
