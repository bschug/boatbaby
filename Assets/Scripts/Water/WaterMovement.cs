using System.Collections;
using System.Collections.Generic;
using TransformExtensions;
using UnityEngine;

public class WaterMovement : MonoBehaviour {

    public float VerticalAmplitude = 10f;
    public float VerticalVelocity = 1f;
    public float PhaseOffset = 0;
    public float HorizontalVelocity = 1f;
    public float Width = 100;

    private void Start () {
        StartCoroutine( HorizontalMovement() );
        StartCoroutine( VerticalMovement() );
    }

    IEnumerator HorizontalMovement() {
        var startX = transform.localPosition.x;
        while (true) {
            for (float x=0; Mathf.Abs(x) < Width; x += Time.deltaTime * HorizontalVelocity) {
                transform.SetLocalX( x );
                yield return null;
            }
        }
    }

    IEnumerator VerticalMovement() {
        var startY = transform.localPosition.y;
        while (true) {
            transform.SetLocalY( startY + Mathf.Sin( Time.time * VerticalVelocity + PhaseOffset ) * VerticalAmplitude );
            yield return null;
        }
    }
}
