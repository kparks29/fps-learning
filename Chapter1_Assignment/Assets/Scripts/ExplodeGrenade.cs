using UnityEngine;
using System.Collections;

public class ExplodeGrenade : MonoBehaviour {

	private GameObject grenade;
	private float explosionRadius = 5;
	private float explosionForce = 20;
	public GameObject explosion;
	public LayerMask explosionLayerMask;
	public EventManager eventManager;

	// Use this for initialization
	void Start () {
		SetInitialReferences ();
		StartCoroutine (StartExplosion ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator StartExplosion () {
		yield return new WaitForSeconds(2);
		Explode (grenade.transform.position);
	}

	void Explode (Vector3 contactPoint) {
		GameObject explosionObj = (GameObject) Instantiate (explosion, grenade.transform.position, Quaternion.identity);
		Destroy (grenade);
		Collider[] hitColliders = Physics.OverlapSphere (grenade.transform.position, explosionRadius, explosionLayerMask);
		foreach (Collider hit in hitColliders) {
			Rigidbody hitRigidbody = hit.GetComponent<Rigidbody> ();
			if (hit.GetComponent<NavMeshAgent> () != null) {
				hit.GetComponent<NavMeshAgent> ().enabled = false;

				if (hit.GetComponent<EnemyChase> ().hasBeenHit == false) {
					eventManager.RemoveEnemies (1);
					hit.GetComponent<EnemyChase> ().hasBeenHit = true;
				}
			}
			if (hitRigidbody != null) {
				hitRigidbody.isKinematic = false;
				hitRigidbody.AddExplosionForce (explosionForce, contactPoint, explosionRadius, 0, ForceMode.Impulse);
				eventManager.RemoveObject (hit.gameObject, 5);
			}
		}
		eventManager.RemoveObject (explosionObj, 1);
		Destroy (grenade);
	}

	void SetInitialReferences () {
		grenade = gameObject;
		eventManager = GameObject.Find ("GameManager").GetComponent<EventManager> ();
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "Enemy") {
			Explode (collision.contacts[0].point);
		}
	}
}
