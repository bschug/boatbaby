using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyCollision : MonoBehaviour {

	Baby _baby;
	ColorManager _colorManager;

	void Start() {

		_baby = GetComponent<Baby>();
		_colorManager = GetComponent<ColorManager>();
	}


	void OnTriggerEnter2D( Collider2D collider ) {

		if ( collider.tag == "water" ) {

			this.gameObject.layer = 9;
		}

		if ( collider.tag == "deathzone" ) {

			_baby.SetToStartPosition();

			this.gameObject.layer = 10;

			_colorManager.PickRandomColor();
		}
	}
}
