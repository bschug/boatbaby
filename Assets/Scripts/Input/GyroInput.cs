using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroInput : SingletonMonoBehaviour<GyroInput> {

    public float GravityMultiplier = 10f;
    public float RollThreshold = 1f;

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
            gravity.y = Mathf.Min(gravity.y, 0);
            gravity.Normalize();
            if (Mathf.Abs(gravity.x) / Mathf.Abs(gravity.y) < RollThreshold) {
                gravity = Vector3.down;
            }
            return gravity * GravityMultiplier;
        }
    }

    bool IsScreenFlipped { get { return Screen.orientation == ScreenOrientation.LandscapeLeft; } }
}
