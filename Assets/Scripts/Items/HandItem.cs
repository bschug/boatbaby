using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandItem : AttachableItem {

	void OnCollisionEnter2D( Collision2D collision ) {
		if ( collision.gameObject.tag == "baby" ) {
			Baby baby = collision.gameObject.GetComponent<Baby>();
			if (IsRightSide(baby.transform.position)) {
                baby.UseInRightHand( this );
            } else {
                baby.UseInLeftHand( this );
            }
		}
	}

	bool  IsRightSide( Vector3 babyPosition ) {
		if ( this.transform.position.x < babyPosition.x  ) {
			return false;
		}

		return true;
	}
}
