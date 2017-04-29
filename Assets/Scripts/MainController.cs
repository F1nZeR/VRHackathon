using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;

public class MainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Data.Controller = this;
		StartCoroutine(InitHeight());
	}

	IEnumerator InitHeight()
	{
		yield return new WaitForSeconds(5);
		RaycastHit hitInfo;
		bool hit = Physics.Raycast(Camera.main.transform.position,
								new Vector3(0, -1, 0),
								out hitInfo,
								3f,
								SpatialMappingManager.Instance.LayerMask);
		var height = Vector3.Distance(Camera.main.transform.position, hitInfo.point);
		Data.FloorHeight = -height;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void KillPlayer()
	{
		// todo: kill user
	}

	public void NotifyAboutHealth(HealthLevel healthLevel)
	{
		// todo: implement GUI
		switch (healthLevel)
		{
			case HealthLevel.SlightlyDamaged:
				break;

			case HealthLevel.MediumDamaged:
				break;

			case HealthLevel.HighlyDamaged:
				break;

			default:
				break;
		}
	}
}
