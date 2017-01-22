using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatItem : AttachableItem {

    void OnCollisionEnter2D ( Collision2D collision ) {

		if ( collision.gameObject.tag == "baby" ) {
			Baby.Instance.UseHat( this );
		}
	}
}
