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

        if (Data.IsEditorModeActive == false)
        {
            StartAlarm();
        }
    }

    public void StartAlarm()
    {
        AlarmSound.SetActive(true);
        Data.IsAlarmPressed = true;
    }

    public void StopAlarm()
    {
        AlarmSound.SetActive(false);
    }
}
