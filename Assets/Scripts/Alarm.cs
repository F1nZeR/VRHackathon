using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class Alarm : PlacementManager
{
    public GameObject AlarmSound;

    public override void OnInputClicked(InputClickedEventData eventData)
    {
        base.OnInputClicked(eventData);
    }

    public void StartAlarm()
    {
        AlarmSound.SetActive(true);
    }

    public void StopAlarm()
    {
        AlarmSound.SetActive(false);
    }
}
