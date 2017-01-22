using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatItem : MonoBehaviour {

    Transform FollowPoint = null;

    private void Update () {
        if (FollowPoint != null) {
            transform.position = FollowPoint.position;
            transform.rotation = FollowPoint.rotation;
        }
    }

    public void AttachTo (Transform followPoint) {
        Debug.Log( "Attaching " + name );
        FollowPoint = followPoint;
        GetComponent<SpriteRenderer>().sortingLayerName = "character_item_front";
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<PointOfInterest>().enabled = false;
    }

    public void Detach () {
        Debug.Log( "Detaching " + name );
        FollowPoint = null;
        GetComponent<SpriteRenderer>().sortingLayerName = "waves_items";
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.layer = LayerMask.NameToLayer( "ItemInWater" );
    }

    void OnCollisionEnter2D ( Collision2D collision ) {

		if ( collision.gameObject.tag == "baby" ) {

			Baby baby = collision.gameObject.GetComponent<Baby>();

			baby.UseHat( this );
		}
	}
}
