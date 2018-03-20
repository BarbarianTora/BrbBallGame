using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	private Transform _curTransform;

	void Start()
	{
		_curTransform = transform;
	}

	void Update () 
	{
		_curTransform.Rotate(new Vector3 (15,30,45) * Time.deltaTime);	
	}
}
