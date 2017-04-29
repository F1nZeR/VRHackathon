using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Baby : PlacementManager
{
    public GameObject BabySound;

    public override void OnInputClicked(InputClickedEventData eventData)
    {
        base.OnInputClicked(eventData);

        if (!IsPlacing)
        {
            AlarmAction();
        }
    }

    public void StartCry()
    {
        BabySound.SetActive(true);
    }

    private void AlarmAction()
    {
        gameObject.SetActive(false);
        BabySound.SetActive(false);
        gameObject.AddComponent<Rigidbody>().mass = 2;
    }
}
