using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;

public class Duststorm : MonoBehaviour 
{
	public Transform MainCamera;

	//public float Height = 0;
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (MainCamera.position.x, Data.GetSmokeHeight(), MainCamera.position.z);
	}
}
