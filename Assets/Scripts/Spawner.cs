using UnityEngine;
using System.Collections;

namespace FPSLearning {
	public class Spawner : MonoBehaviour {

		public int numberOfEnemies;
		public GameObject objectToSpawn;
		private float spawnRadius = 5;
		private Vector3 spawnPosition;

		// Use this for initialization
		void Start () {
			SpawnObject ();
		}

		void SpawnObject () {
			for (int i = 0; i < numberOfEnemies; i++) {
				spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
				Instantiate (objectToSpawn, spawnPosition, Quaternion.identity);
			}
		}
	}
}