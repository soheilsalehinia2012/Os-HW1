﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	
	private Transform _t;
	
	void Awake(){
		camera.orthographicSize = ((Screen.height / 1.5f) / 50f);
	}
	
	// Use this for initialization
	void Start () {
		_t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(_t)
			transform.position = new Vector3 (_t.position.x, _t.position.y, transform.position.z);
	}
}
