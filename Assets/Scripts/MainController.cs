using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;

public class MainController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		Data.Controller = this;
		StartCoroutine(InitHeight());
	}

	float GetCurrentPlayerHeight()
	{
		var floorHeight = Data.FloorHeight;
		var curCameraHeight = Camera.main.transform.position.y;
		return curCameraHeight - floorHeight;
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
	void Update ()
    {
		if (Data.IsSmokeActivated)
		{
			if (GetCurrentPlayerHeight() >= Data.GetSmokeHeight())
			{
				Data.DamagePlayer(DamageType.Smoke);
			}
			else
			{
				Data.HealPlayer(DamageType.Smoke);
			}
		}
	}

	public void KillPlayer()
	{
		// todo: kill user
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
