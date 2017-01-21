using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatItem : MonoBehaviour {

	void OnCollisionEnter2D( Collision2D collision ) {

		if ( collision.gameObject.tag == "baby" ) {

			collision.gameObject.GetComponent<Baby>().UseHat( this );
		}
	}
}
