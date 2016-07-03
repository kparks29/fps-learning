using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject enemy;
	private Transform spawnerTransform;
	private int numEnemiesToSpawn = 5;
	private float spawnRadius = 5f;
	private Vector3 spawnPosition;
	private EventManager eventManagerScript;

	void OnEnable () {
		SetInitialReferences ();
		eventManagerScript.openTreasureEvent += SpawnEnemies;
	}

	void OnDisable () {
		eventManagerScript.openTreasureEvent -= SpawnEnemies;
	}

	void SpawnEnemies () {
		for (int i = 0; i < numEnemiesToSpawn; i++) {
			spawnPosition = spawnerTransform.position + Random.insideUnitSphere * spawnRadius;
			Instantiate (enemy, spawnPosition, Quaternion.identity);
		}
	}

	void SetInitialReferences () {
		eventManagerScript = GameObject.Find ("GameManager").GetComponent<EventManager> ();
		spawnerTransform = transform;
	}
}
