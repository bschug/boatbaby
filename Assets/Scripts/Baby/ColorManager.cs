using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {

	public List<Color> _colors;
	public SpriteRenderer _target;

	public void PickRandomColor() {

		int randomNumber = Random.Range( 0, _colors.Count );

		_target.color = _colors[ randomNumber ];
	}


}
