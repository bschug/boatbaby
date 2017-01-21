﻿using NumericTypeExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : SingletonMonoBehaviour<Baby> {

    public float ResetDuration = 1.5f;

	Animator _animator;
    Rigidbody2D Rigidbody2D;

    Quaternion NeutralRotation;
    Vector3 NeutralPosition;
    bool IsResetting = false;

	override protected void Awake() {
        base.Awake();

		if ( GetComponent<Animator>() != null ) {
			_animator = GetComponent<Animator>();
		}
		else {
			Debug.LogWarning( "Baby has no animator" );
		}

        Rigidbody2D = GetComponent<Rigidbody2D>();

        NeutralPosition = transform.position;
        NeutralRotation = transform.rotation;
	}

	public void Eat( EatableItem item ) {

		if ( _animator != null ) {

			_animator.SetTrigger( "eatAnim" );
		}
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

    public bool AllowRolling {
        set {
            if (value) {
                Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            } else {
                if (Rigidbody2D.bodyType == RigidbodyType2D.Kinematic) {
                    return;
                }
                Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                StartCoroutine( Co_TweenToStartPosition( ResetDuration ) );
            }
        }
    }

    IEnumerator Co_TweenToStartPosition(float duration) {
        var startTime = Time.time;
        var startRotation = transform.rotation.eulerAngles.z;
        var targetRotation = NeutralRotation.eulerAngles.z;
        var startPosition = transform.position;
        IsResetting = true;

        while (Time.time - startTime < duration) {
            // Abort if rolling is re-enabled
            if (Rigidbody2D.bodyType == RigidbodyType2D.Dynamic) {
                break;
            }

            var t = (Time.time - startTime) / duration;
            transform.rotation = Quaternion.Euler( 0, 0, Mathf.Lerp( startRotation, targetRotation, t ) );
            transform.position = Vector3.Lerp( startPosition, NeutralPosition, t );
            yield return null;
        }

        IsResetting = false;
    }

    private void OnGUI () {
        GUILayout.Label( IsResetting ? "Resetting" : "not resetting" );
    }
}
