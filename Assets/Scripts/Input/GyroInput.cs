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
        Baby.Instance.AllowRolling = IsExtremelyTilted;
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

    bool IsExtremelyTilted {
        get {
            return Mathf.Abs( Input.gyro.gravity.x ) > Mathf.Abs( Input.gyro.gravity.y );
        }
    }

    private void OnGUI () {
        GUILayout.Label( IsExtremelyTilted ? "TILTED" : "normal" );
    }
}
