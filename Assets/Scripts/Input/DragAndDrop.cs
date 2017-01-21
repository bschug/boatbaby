using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

	public GameObject 	_target;
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

			_ray =  _mainCamera.ScreenPointToRay( new Vector2( Input.mousePosition.x, Input.mousePosition.y) );

			_hit = Physics2D.Raycast( _ray.origin, _ray.origin );

			if ( _hit.collider != null && _hit.collider.tag == "baby" || _hit.collider != null && _hit.collider.tag == "item" ) {

				_target = _hit.collider.gameObject;
			}
		}

		if ( Input.GetMouseButton( 0 ) == true ) {

			if ( _target != null ) {

				Vector3 worldPos = Camera.main.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, 0 ) );

				_target.transform.position = new Vector3( worldPos.x, worldPos.y, _target.transform.position.z );
			}
		}

		if ( Input.GetMouseButtonUp( 0 ) == true ) {

			if ( _target != null ) {

				_target.layer = 10;
				_target = null;
			}
		}
	}
}
