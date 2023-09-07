using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Mover : MonoBehaviour
{
    public class EndMoveEvent : UnityEvent { }
    private EndMoveEvent onEndMoveEvent;

    private RectTransform rectTransform;
    private float moveTime = 1.0f;
    private bool isMoving = false;

    private void Awake()
    {
        onEndMoveEvent = new EndMoveEvent();
        rectTransform = GetComponent<RectTransform>();
    }

    public void StartMoving(UnityAction action, Vector3 end)
    {
        if ( isMoving == false )
        {
            onEndMoveEvent.AddListener(action);

            StartCoroutine(MoveTo(action, end));
        }
    }

    private IEnumerator MoveTo(UnityAction action, Vector3 end)
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

        onEndMoveEvent.Invoke();

        onEndMoveEvent.RemoveListener(action);
    }
}
