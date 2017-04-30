using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class Clicker : MonoBehaviour, IInputClickHandler
{
    public MainController controller;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        controller.StartVoice();
        gameObject.SetActive(false);
    }
}
