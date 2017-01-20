using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D collider ) {

		if ( collider.tag == "deathzone" ) {

			Destroy( this.gameObject );
		}
	}
}
