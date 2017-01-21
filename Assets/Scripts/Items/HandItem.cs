using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandItem : MonoBehaviour {

	void OnCollisionEnter2D( Collision2D collision ) {

		if ( collision.gameObject.tag == "baby" ) {

			bool isRightHand;

			if ( this.transform.position.x < collision.transform.position.x  ) {

				isRightHand = false;
			}

			else {

				isRightHand = true;
			}

			collision.gameObject.GetComponent<Baby>().UseHandItem( this, isRightHand );
		}
	}
}
