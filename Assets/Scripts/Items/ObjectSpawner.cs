using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	[SerializeField] List<GameObject> _objectList = new List<GameObject>();
	[SerializeField] List<GameObject> _spawnedObjects = new List<GameObject>();
	[SerializeField] float _minSpawnTime;
	[SerializeField] float _maxSpawnTime;
	[SerializeField] Transform _spawnPosition;

	bool _isActive;

	// Use this for initialization
	void Start () {

		StartCoroutine( SpawnRoutine() );
	}
	
	IEnumerator SpawnRoutine() {

		_isActive = true;

		while ( _isActive ) {

			int randomObject = Random.Range( 0, _objectList.Count );

			GameObject newObject = Instantiate( _objectList[ randomObject ] );
			newObject.transform.position = _spawnPosition.position;
			_spawnedObjects.Add( newObject );

			yield return new WaitForSeconds( Random.Range( _minSpawnTime, _maxSpawnTime ) );
		}
	}
}
