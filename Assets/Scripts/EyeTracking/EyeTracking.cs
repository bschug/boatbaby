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

    List<PointOfInterest> PointsOfInterest = new List<PointOfInterest>();

    public void AddPointOfInterest (PointOfInterest poi) {
        PointsOfInterest.Add( poi );
        Debug.Log( "Added POI " + poi.name );
    }

    public void RemovePointOfInterest (PointOfInterest poi) {
        PointsOfInterest.Remove( poi );
        Debug.Log( "Removed POI " + poi.name );
    }

    private void Update () {
        SetLookDirection( LookDirection );
    }

    Vector2 LookDirection {
        get {
            var direction = MostInterestingPoint - Baby.Instance.ScreenPosition;
            direction.Normalize();
            return direction;
        }
    }

    Vector2 MostInterestingPoint {
        get {
            if (PointsOfInterest.Count == 0) {
                return Input.mousePosition;
            }
            return PointsOfInterest
                .OrderBy( poi => Vector3.Distance(Baby.Instance.ScreenPosition, poi.ScreenPosition) )
                .OrderBy( poi => -poi.Priority )
                .First()
                .ScreenPosition;
        }
    }
    
    void SetLookDirection(Vector2 position) {
        Animator.SetFloat( "x", position.x );
        Animator.SetFloat( "y", position.y );
    }
}
