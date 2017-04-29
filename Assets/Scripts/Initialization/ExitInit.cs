using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInit : MonoBehaviour, IInitializable
{
    private PlacementManager _placementManager;
    public event Action<GameObject> InitializationFinished;

    public void StartInitialization()
    {
        _placementManager = gameObject.GetComponent<PlacementManager>();
        _placementManager.StartPlacement();
        _placementManager.PlacementFinished += PlacementManager_PlacementFinished;
    }

    private void PlacementManager_PlacementFinished()
    {
        _placementManager.PlacementFinished -= PlacementManager_PlacementFinished;

        if (InitializationFinished != null)
        {
            InitializationFinished(this.gameObject);
        }
    }
}
