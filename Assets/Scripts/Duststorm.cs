using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duststorm : MonoBehaviour 
{

	public Transform MainCamera;

	public float Height = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (MainCamera.position.x, Height, MainCamera.position.z);
	}
}
