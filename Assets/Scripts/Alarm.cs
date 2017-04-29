using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class Alarm : PlacementManager
{
    public GameObject AlarmSound;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
