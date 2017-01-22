using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandItem : MonoBehaviour {

    Transform FollowPoint = null;

    private void Update () {
        if (FollowPoint != null) {
            transform.position = FollowPoint.position;
            transform.rotation = FollowPoint.rotation;
        }
    }

    public void AttachTo(Transform followPoint) {
        FollowPoint = followPoint;
        GetComponent<SpriteRenderer>().sortingLayerName = "character_item_front";
    }

    public void Detach() {
        FollowPoint = null;
        GetComponent<SpriteRenderer>().sortingLayerName = "waves_items";
    }

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
