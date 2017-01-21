using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandItem : MonoBehaviour {

	void OnCollisionEnter2D( Collision2D collision ) {

		if ( collision.gameObject.tag == "baby" ) {

			Baby baby = collision.gameObject.GetComponent<Baby>();
			
			baby.UseHandItem( this, IsRightSide( baby.transform.position ) );
		}
	}

	bool  IsRightSide( Vector3 babyPosition ) {

		if ( this.transform.position.x < babyPosition.x  ) {

			return false;
		}

		return true;
	}
}
