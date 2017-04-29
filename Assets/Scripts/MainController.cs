using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    Data.Controller = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public GameObject ExitObject;

    public void CollidedWith(GameObject collidedWith)
    {
        if (collidedWith == ExitObject)
        {
            StartExitProcedure();
        }
    }

    private void StartExitProcedure()
    {
        //TODO:EXIT!!
    }
}
