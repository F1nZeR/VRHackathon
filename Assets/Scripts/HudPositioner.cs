using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudPositioner : MonoBehaviour
{
    public Transform PositionToFollow;
	
	// Update is called once per frame
	void Update ()
	{
	    gameObject.transform.position = PositionToFollow.position + PositionToFollow.forward * 1.5f;
	    gameObject.transform.rotation = PositionToFollow.rotation;
	}
}
