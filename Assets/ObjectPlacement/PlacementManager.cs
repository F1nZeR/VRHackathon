using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;

public class PlacementManager : MonoBehaviour, IInputClickHandler
{
    public string AnchorFriendlyName = "CHANGE_ME_AnchorFriendlyNameItIsGlobal!!!";
    public GameObject ObjectToPlace = null;
    private bool _isPlacing = false;

    protected bool IsPlacing
    {
        get { return _isPlacing; }
        set
        {
            if (_isPlacing == value)
            {
                return;
            }

            _isPlacing = value;
            if (_isPlacing == false && PlacementFinished != null)
            {
                PlacementFinished();
            }
        }
    }

    protected GameObject Object
    {
        get
        {
            if (ObjectToPlace == null)
            {
                return gameObject;
            }
            else
            {
                return ObjectToPlace;
            }
        }
    }

    // Use this for initialization
    void Start ()
    {
        Debug.Log("START");

        if (WorldAnchorManager.Instance == null)
        {
            Debug.LogError("This script expects that you have a WorldAnchorManager component in your scene.");
        }

        if (SpatialMappingControl.Instance == null)
        {
            Debug.LogError("This script expects that you have a SpatialMapping component in your scene.");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (IsPlacing)
        {
            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 100.0f, SpatialMappingControl.PhysicsRaycastMask))
            {
                SetPosition(hitInfo);
            }
        }
    }

    protected virtual void SetPosition(RaycastHit hitInfo)
    {
        // Move this object to where the raycast
        // hit the Spatial Mapping mesh.
        // Here is where you might consider adding intelligence
        // to how the object is placed.  For example, consider
        // placing based on the bottom of the object's
        // collider so it sits properly on surfaces.
        Object.transform.position = hitInfo.point;

        // Rotate this object to face the user.
        Quaternion toQuat = Camera.main.transform.localRotation;
        toQuat.x = 0;
        toQuat.z = 0;
        Object.transform.rotation = toQuat;
    }

    private void Go()
    {
        Debug.Log("GO");

        // If the user is in placing mode, display the spatial mapping mesh.
        if (IsPlacing)
        {
            //spatialMapping.DrawVisualMeshes = true;

            Debug.Log(Object.name + " : Removing existing world anchor if any.");

            WorldAnchorManager.Instance.RemoveAnchor(Object);
        }
        // If the user is not in placing mode, hide the spatial mapping mesh.
        else
        {
            //spatialMapping.DrawVisualMeshes = false;
            // Add world anchor when object placement is done.
            WorldAnchorManager.Instance.AttachAnchor(Object, AnchorFriendlyName);
        }
    }

    public void StartPlacement()
    {
        IsPlacing = true;
        Go();
    }

    public virtual void OnInputClicked(InputClickedEventData eventData)
    {
        if (IsPlacing == false && Data.IsEditorModeActive == false)
        {
            eventData.Reset();
            return;
        }

        IsPlacing = !IsPlacing;
        Go();

        eventData.Use();
    }

    public event Action PlacementFinished;
}
