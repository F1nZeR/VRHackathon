using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickGenerator : MonoBehaviour {
	private int Count = 2;
    private float UpOffset = 2;
    private float FrontOffset = 4;
	public Transform Prefab;

    public Transform Camera;

    private List<Transform> _objects;

	// Use this for initialization
	void Start () {
		_objects = new List<Transform> ();
        InvokeRepeating("Generate", 10, 8);
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonUp (0)) {
			Generate ();
		}
	}

	public void Generate()
	{
        //ClearObjects();
        for (int i = 0; i < Count; i++) {
			var obj = Object.Instantiate (Prefab);

            obj.rotation = Random.rotation;
            obj.position = Camera.transform.position + Camera.transform.forward * (FrontOffset + i) + Vector3.up * UpOffset;
            _objects.Add(obj);
		}
	}

    public void ClearObjects()
    {
        foreach (var obj in _objects)
        {
            Object.Destroy(obj.gameObject);
        }
        _objects.Clear();
    }
}
