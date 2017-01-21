using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour {
    public float Priority = 1;

    private void OnEnable() {
        EyeTracking.Instance.AddPointOfInterest( this );
    }

    private void OnDisable () {
        EyeTracking.Instance.RemovePointOfInterest( this );
    }

    public Vector3 Position {
        get { return transform.position; }
    }
}
