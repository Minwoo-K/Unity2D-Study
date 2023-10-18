using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEvent : MonoBehaviour
{
    [SerializeField]
    private UI_Mover ui_Mover;

    [SerializeField]
    private GameObject buttons;
    [SerializeField]
    private GameObject message;
    [SerializeField]
    private float timeGapBtwnEvent;

    private Action events = null;
    private RectTransform rectTransform;
    private Vector3 inactivePosition = Vector3.up * 300;
    private Vector3 activePosition = Vector3.zero;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = inactivePosition;

        EventStart();
    }

    private void EventStart()
    {
        events = events + GetButtonsOn + GetMessageOn;
        ui_Mover.StartMoving(events, activePosition);
    }

    private void GetButtonsOn()
    {
        buttons.SetActive(true);
    }

    private void GetMessageOn()
    {
        message.SetActive(true);
    }
}
