using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {


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

			_ray =  _mainCamera.ScreenPointToRay( new Vector2( Input.mousePosition.x, Input.mousePosition.y) );

			_hit = Physics2D.Raycast( _ray.origin, _ray.origin );

			if ( _hit.collider != null && _hit.collider.tag == "baby" ) {

				_target = _hit.collider.gameObject;

				_target.GetComponent<Baby>().React();
			}
		}
	}
}
