using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : SingletonMonoBehaviour<Baby> {

	public void Eat( EatableItem item ) {

		Debug.Log( "Hamjamham" );
	}

	public void SetToStartPosition() {

		this.transform.position = new Vector3( 0, 1.1f, 0 );
	}
}
