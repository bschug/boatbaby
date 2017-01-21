using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Baby : SingletonMonoBehaviour<Baby> {

	public void Eat( EatableItem item ) {

		Debug.Log( "Hamjamham" );
	}

    public void Sleep()
    {
        Debug.Log("ZZZzzzzz");
    }

    public void WakeUp()
    {
        Debug.Log("Hahahahaha");
    }

	public void SetToStartPosition() {

		this.transform.position = new Vector3( 0, 1.1f, 0 );
	}

    public Vector2 ScreenPosition {
        get {
            return Camera.main.WorldToScreenPoint( transform.position );
        }
    }

}
