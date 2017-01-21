using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using NumericTypeExtensions;

public class EyeTracking : SingletonMonoBehaviour<EyeTracking>
{
    public float MinDistance = 10;
    public float MaxDistance = 200;

    [SerializeField]
    Animator Animator;

    List<PointOfInterest> PointsOfInterest;

    public void AddPointOfInterest (PointOfInterest poi) {
        PointsOfInterest.Add( poi );
    }

    public void RemovePointOfInterest (PointOfInterest poi) {
        PointsOfInterest.Remove( poi );
    }

    private void Update () {
        SetLookDirection( LookDirection );
    }

    Vector2 LookDirection {
        get {
            var direction = MostInterestingPoint - Baby.Instance.ScreenPosition;
            //            direction.x = direction.x / Screen.width * 2;
            //            direction.y = direction.y / Screen.height * 2;
            direction.Normalize();
            return direction;
        }
    }

    Vector2 MostInterestingPoint {
        get {
            return Input.mousePosition;
//            if (PointsOfInterest.Count == 0) {
//                return null;
//            }
//            return PointsOfInterest.OrderBy( poi => poi.Priority ).Last();
        }
    }

    private void OnGUI () {
        GUILayout.Label( "bla:" + LookDirection.ToString() );
    }

    void SetLookDirection(Vector2 position) {
        Animator.SetFloat( "x", position.x );
        Animator.SetFloat( "y", position.y );
    }
}
