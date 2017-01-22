using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorItem : MonoBehaviour {

	ColorManager _colorManager;
	Color _color;

	void Start() {

		_colorManager = Baby.Instance.GetComponent<ColorManager>();
		_color = _colorManager.GetRandomColor();

		this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = _color;
	}

	void OnCollisionEnter2D( Collision2D collision ) {

		if ( collision.gameObject.tag == "baby" ) {

			Baby baby = collision.gameObject.GetComponent<Baby>();

			_colorManager.SetColor( _color );

			Destroy( this.gameObject );
		}
	}
}
