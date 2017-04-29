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

        if (!IsPlacing)
        {
            AlarmAction();
        }
    }

    private void AlarmAction()
    {
        AlarmSound.SetActive(true);
    }
}
