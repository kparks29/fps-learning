using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {

	private float checkRate;
	private Transform enemyTransform;
	private NavMeshAgent enemyNavMeshAgent;
	private float nextCheck;
	private float detectionRadius = 50f;
	private Collider[] hitColliders;
	public bool hasBeenHit = false;

	public LayerMask detectionLayer;

	// Use this for initialization
	void Start () {
		SetInitialReferences ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckIfPlayerInRange ();
	}

	void SetInitialReferences() {
		enemyTransform = transform;
		checkRate = Random.Range (0.8f, 1.2f);
		enemyNavMeshAgent = transform.GetComponent<NavMeshAgent> ();
	}

	void CheckIfPlayerInRange () {
		if (Time.time > nextCheck && enemyNavMeshAgent.enabled) {
			nextCheck = Time.time + checkRate;

			hitColliders = Physics.OverlapSphere (enemyTransform.position, detectionRadius, detectionLayer);

			if (hitColliders.Length > 0) {
				enemyNavMeshAgent.SetDestination (hitColliders [0].transform.position);
			}
		}
	}
}
