using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("works1");
        Data.Controller.CollidedWith(collision.gameObject);
    }

    public void OnTriggerStay(Collider collider)
    {
        Debug.Log("works");
        Data.Controller.CollidedWith(collider.gameObject);
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
