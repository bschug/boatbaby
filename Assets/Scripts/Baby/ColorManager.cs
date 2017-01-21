using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {

	public List<Color> _colors;
	public List<SpriteRenderer> _targets = new List<SpriteRenderer>();

	public void PickRandomColor() {

		int randomNumber = Random.Range( 0, _colors.Count );

		for ( int i = 0; i < _targets.Count; i++ ) {

			_targets[i].color = _colors[randomNumber];
		}
	}
}
