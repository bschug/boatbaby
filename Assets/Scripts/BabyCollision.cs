﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyCollision : MonoBehaviour {


	void OnTriggerEnter2D( Collider2D collider ) {

		if ( collider.tag == "water" ) {

			this.gameObject.layer = 9;
		}
	}
}
