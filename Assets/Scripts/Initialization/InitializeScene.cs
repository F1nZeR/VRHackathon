using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeScene : MonoBehaviour
{
    public GameObject[] ObjectsToInit;

    private IInitializable _controllerToStart = null;
    private int _framesToSkip = 0;
    // Use this for initialization
    void Start()
    {
        foreach (var item in ObjectsToInit)
        {
            item.SetActive(false);
        }

        if (ObjectsToInit.Length > 0)
        {
            ObjectsToInit[0].SetActive(true);
            var controller = ObjectsToInit[0].GetComponent<IInitializable>();
            controller.InitializationFinished += this.FinishInitialization;
            _controllerToStart = controller;
            _framesToSkip = 9;
        }
    }

    private void LateUpdate()
    {
        if (_controllerToStart != null && _framesToSkip > 10)
        {
            var control = _controllerToStart;
            _controllerToStart = null;
            control.StartInitialization();
        }

        _framesToSkip++;
    }

    public void FinishInitialization(GameObject go)
    {
        var controller = go.GetComponent<IInitializable>();
        controller.InitializationFinished -= FinishInitialization;

        var currentIndex = Array.IndexOf(ObjectsToInit, go);
        currentIndex++;

        if (currentIndex < ObjectsToInit.Length)
        {
            var newGO = ObjectsToInit[currentIndex];
            newGO.SetActive(true);
            var newController = newGO.GetComponent<IInitializable>();
            newController.InitializationFinished += FinishInitialization;
            _controllerToStart = newController;
            _framesToSkip = 0;
        }
        else
        {
            SpatialMappingControl.Instance.DrawVisualMeshes = false;

            GetComponent<MainController>().Ready();

            Destroy(this);
        }
    }
}
