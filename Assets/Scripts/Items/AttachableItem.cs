using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachableItem : MonoBehaviour {

    Transform FollowPoint = null;
    SpriteRenderer SpriteRenderer;
    List<Collider2D> AllColliders;

    protected void Awake () {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        if (SpriteRenderer == null) {
            SpriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        }
        AllColliders = FindAllColliders();
    }

    protected void Update () {
        if (FollowPoint != null) {
            transform.position = FollowPoint.position;
            transform.rotation = FollowPoint.rotation;
        }
    }

    public void AttachTo (Transform followPoint) {
        Debug.Log( "Attaching " + name );
        FollowPoint = followPoint;
        SpriteRenderer.sortingLayerName = "character_item_front";
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<PointOfInterest>().enabled = false;
        DisableColliders();
    }

    public void Detach () {
        Debug.Log( "Detaching " + name );
        FollowPoint = null;
        SpriteRenderer.sortingLayerName = "waves_items";
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.layer = LayerMask.NameToLayer( "ItemInWater" );
        EnableColliders();
    }

    List<Collider2D> FindAllColliders() {
        var result = new List<Collider2D>();
        result.AddRange( GetComponents<BoxCollider2D>() );
        result.AddRange( GetComponents<CircleCollider2D>() );
        result.AddRange( transform.GetComponentsInChildren<BoxCollider2D>() );
        result.AddRange( transform.GetComponentsInChildren<CircleCollider2D>() );
        return result;
    }

    void DisableColliders() {
        AllColliders.ForEach( x => { x.enabled = false; } );
    }

    void EnableColliders() {
        AllColliders.ForEach( x => { x.enabled = true; } );
    }
}
