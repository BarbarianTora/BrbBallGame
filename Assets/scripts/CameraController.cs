using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	[SerializeField]
	private Transform _playerTransform = null;

	private Vector3 _offset = Vector3.zero;
	private Transform _curTransform = null;

	void Start () 
	{
		_offset = transform.position - _playerTransform.position;
		_curTransform = transform;
	}

	void LateUpdate ()
	{
		_curTransform.position = _playerTransform.position + _offset;
	}
}
