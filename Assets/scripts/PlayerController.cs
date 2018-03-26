using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public delegate void PickUpObjectHandler();
	public event PickUpObjectHandler OnPickUpObject;

	//public Vector3 movement { get; set; }
	//public VirtualJoystick joystick;

	public float speed;

	private Rigidbody _rb;

	void Start() 
	{
		_rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{   
		float moveHorizontal = Input.GetAxis ( "Horizontal" );
		float moveVertical = Input.GetAxis ( "Vertical" );

		Vector3 movement = new Vector3 ( moveHorizontal, 0.0f, moveVertical ); 

		/* Vector3 movement = new Vector3 ();
		movement.x = (joystick.Horizontal( ) );
		movement.z = (joystick.Vertical( ) );  */

		_rb.AddForce ( movement * speed ); 
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
