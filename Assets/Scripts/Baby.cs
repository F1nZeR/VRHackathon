using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Baby : PlacementManager
{
    public override void OnInputClicked(InputClickedEventData eventData)
    {
        if (Data.IsEditorModeActive == false)
        {
            gameObject.SetActive(false);
            StopCry();
            Data.IsBabyTaken = true;
        }

        base.OnInputClicked(eventData);
    }

    protected override void SetPosition(RaycastHit hitInfo)
    {
        // Move this object to where the raycast
        // hit the Spatial Mapping mesh.
        // Here is where you might consider adding intelligence
        // to how the object is placed.  For example, consider
        // placing based on the bottom of the object's
        // collider so it sits properly on surfaces.
        Object.transform.position = hitInfo.point - Camera.main.transform.forward * 1.2f;

        // Rotate this object to face the user.
        Quaternion toQuat = Camera.main.transform.localRotation;
        toQuat.x = 0;
        toQuat.z = 0;
        Object.transform.rotation = toQuat;
    }

    public void StartCry()
    {
        GetComponent<AudioSource>().mute = false;
    }

    public void StopCry()
    {
        GetComponent<AudioSource>().mute = true;

    }
}
