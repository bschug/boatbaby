using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroGravity : SingletonMonoBehaviour<GyroGravity> {

    public float GravityMultiplier = 10f;

    override protected void Awake() {
        base.Awake();
        Input.gyro.enabled = true;
    }

    void Update() {
        Physics2D.gravity = AdjustedGravity;
    }

    Vector2 AdjustedGravity
    {
        get
        {
            var gravity = Input.gyro.gravity;
            // Invert gravity if screen is flipped
            //if (IsScreenFlipped) {
            //    gravity *= -1;
            //}
            // Don't float up if screen is upside down and hasn't auto-rotated yet
            gravity.y = Mathf.Min(gravity.y, 0);
            return gravity * GravityMultiplier;
        }
    }

    bool IsScreenFlipped { get { return Screen.orientation == ScreenOrientation.LandscapeLeft; } }
}
