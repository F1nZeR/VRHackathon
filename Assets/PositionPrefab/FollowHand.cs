using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class FollowHand : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(Camera.main.transform.position,
                                new Vector3(0, -1, 0),
                                out hitInfo,
                                20f,
                                SpatialMappingManager.Instance.LayerMask);		
        var distance = Vector3.Distance(Camera.main.transform.position, hitInfo.point);
        Debug.Log(distance);
	}
}
