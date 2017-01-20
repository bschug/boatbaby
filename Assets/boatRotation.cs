using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatRotation : MonoBehaviour {

	[SerializeField] float _rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if ( Input.GetKey( KeyCode.LeftArrow ) || Input.GetKey( KeyCode.A ) ) {

			this.transform.Rotate( new Vector3( 0, 0,  _rotationSpeed * Time.deltaTime) );

			Debug.Log( "Rotate left" );
		}

		else if ( Input.GetKey( KeyCode.RightArrow ) || Input.GetKey( KeyCode.D ) ) {

			this.transform.Rotate(  new Vector3( 0, 0, - _rotationSpeed * Time.deltaTime) );

			Debug.Log( "Rotate right" );
		} 
	}
}
