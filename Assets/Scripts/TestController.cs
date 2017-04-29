using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{

    public GameObject Object;

	// Use this for initialization
	void Start ()
	{

	    Object.GetComponent<PlacementManager>().StartPlacement();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
