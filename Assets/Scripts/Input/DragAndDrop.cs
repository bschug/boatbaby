using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

	public PointOfInterest 	_pointOfInterest;

	GameObject 			_target;
	Ray 				_ray = new Ray();
	RaycastHit2D 		_hit = new RaycastHit2D();
	Camera 				_mainCamera;

	// Use this for initialization
	void Start () {

		_mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

		if ( Input.GetMouseButtonDown( 0 ) == true ) {
			GetTarget();
			EnablePointOfInterest();
		}

        if (_target != null) {
            Baby.Instance.IsAnticipating = true;
        }

        if ( Input.GetMouseButton( 0 ) == true ) {
			Vector3 position = GetPosition();
			MoveTarget( position );
			MovePointOfInterest( position );
		}

		if ( Input.GetMouseButtonUp( 0 ) == true ) {
			RemoveTarget();
			DisablePointOfInterest();
            Baby.Instance.IsAnticipating = false;
		}
	}

	Vector3 GetPosition() {

		Vector3 worldPos = Camera.main.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, 0 ) );
		return worldPos = new Vector3( worldPos.x, worldPos.y, 0 );	
	}

	void GetTarget() {

		_ray =  _mainCamera.ScreenPointToRay( new Vector2( Input.mousePosition.x, Input.mousePosition.y) );

		_hit = Physics2D.Raycast( _ray.origin, _ray.origin );

		if ( _hit.collider != null && _hit.collider.tag == "item" ) {

			_target = _hit.collider.gameObject;
		}

		else if ( _hit.collider != null && _hit.collider.tag == "baby" && _hit.collider.gameObject.layer != 10 ) {

			_target = _hit.collider.gameObject;
		}
	}

	void RemoveTarget() {

		if ( _target != null ) {

			_target.layer = 10;
			_target = null;
		}
	}

	void MoveTarget( Vector3 position ) {

		if ( _target != null ) {

			_target.transform.position = position;
		}
	}

	void EnablePointOfInterest() {

		if ( _pointOfInterest != null ) {

			_pointOfInterest.enabled = true;
		}

		else {

			Debug.LogWarning( "No Point of Interest set" );
		}
	}

	void DisablePointOfInterest() {

		if ( _pointOfInterest != null ) {

			_pointOfInterest.enabled = false;
		}
	}

	void MovePointOfInterest( Vector3 position ) {

		if ( _pointOfInterest != null && _pointOfInterest.enabled == true ) {

			_pointOfInterest.transform.position = position;
		}
	}
}
