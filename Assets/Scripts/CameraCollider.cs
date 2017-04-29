using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Data.Controller.CollidedWith(collision.gameObject);
    }

    // Use this for initialization
    void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
