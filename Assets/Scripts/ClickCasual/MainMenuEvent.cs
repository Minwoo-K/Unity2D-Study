using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEvent : MonoBehaviour
{
    [SerializeField]
    private UI_Mover ui_Mover;

    [SerializeField]
    private RectTransform mainTitle;
    [SerializeField]
    private GameObject buttons;
    [SerializeField]
    private GameObject message;
    [SerializeField]
    private float timeGapBtwnEvent;

    private Action events = null;
    private Vector3 inactivePosition = Vector3.up * 300;
    private Vector3 activePosition;

    private void Start()
    {
        activePosition = mainTitle.anchoredPosition;
        mainTitle.anchoredPosition = inactivePosition;

        EventStart();
    }

    private void EventStart()
    {
        events += GetButtonsOn;
        ui_Mover.StartMoving(events, activePosition);

        StartCoroutine(GetMessageOn());
    }

    private void GetButtonsOn()
    {
        buttons.SetActive(true);
    }

    private IEnumerator GetMessageOn()
    {
        yield return new WaitForSeconds(timeGapBtwnEvent);

        message.SetActive(true);
    }
}
