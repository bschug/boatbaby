using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

	[SerializeField] float _fadeInTime;

	SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start () {

		_spriteRenderer = this.GetComponent<SpriteRenderer>();

		StartCoroutine( FadeInRoutine() );
	}

	IEnumerator FadeInRoutine() {

		float change = 1.0f / _fadeInTime;

		float time = 0.0f;
		float alpha;

		while( Input.GetMouseButtonDown( 0 ) == false ) {

			yield return null;
		}

		while ( time < 1.0 ) {

			time += change * Time.deltaTime;
		 	alpha = Mathf.Lerp( 1.0f, 0.0f, time );
			_spriteRenderer.color = new Color( _spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, alpha);

			yield return null;
		}

		Destroy( this.gameObject );
	}
}
