using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public delegate void PickUpObjectHandler();
	public event PickUpObjectHandler OnPickUpObject;
	public VirtualJoystick moveJoystick;

	public float speed;

	private Rigidbody _rb;

	void Start() 
	{
		_rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{   
		Vector3 dir = Vector3.zero;

		dir.x = Input.GetAxis ( "Horizontal" );
		dir.y = Input.GetAxis ( "Vertical" );

		if (moveJoystick.inputDirection != Vector3.zero)
			dir = moveJoystick.inputDirection;

		_rb.AddForce ( dir * speed ); 
	}

	void OnTriggerEnter( Collider other )
	{
		if (other.gameObject.CompareTag( "PickUp" ) ) 
		{
			other.gameObject.SetActive( false );

			if ( OnPickUpObject != null ) 
				OnPickUpObject();
		}
	}

}
