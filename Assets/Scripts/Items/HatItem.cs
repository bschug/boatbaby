using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatItem : AttachableItem {

    override protected void Awake() {
        base.Awake();
        SortingLayerWhenAttached = "character_item_back";
    }

    void OnCollisionEnter2D ( Collision2D collision ) {

		if ( collision.gameObject.tag == "baby" ) {
			Baby.Instance.UseHat( this );
		}
	}
}
