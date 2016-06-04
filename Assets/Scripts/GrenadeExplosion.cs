using UnityEngine;
using System.Collections;

namespace FPSLearning {
	public class GrenadeExplosion : MonoBehaviour {

		private Collider[] hitColliders;
		public float blastRadius;
		public float explosionPower;
		public LayerMask explosionLayers;

		void OnCollisionEnter (Collision collision) {
			ExplosionWork (collision.contacts [0].point);
			Destroy (gameObject);
		}

		void ExplosionWork (Vector3 explosionPoint) {
			hitColliders = Physics.OverlapSphere (explosionPoint, blastRadius, explosionLayers);

			foreach (Collider hitCollider in hitColliders) {
				//Debug.Log (hitCollider.gameObject.name);
				if (hitCollider.GetComponent<NavMeshAgent> () != null) {
					hitCollider.GetComponent<NavMeshAgent> ().enabled = false;
				}

				if (hitCollider.GetComponent<Rigidbody> () != null) {
					hitCollider.GetComponent<Rigidbody> ().isKinematic = false;
					hitCollider.GetComponent<Rigidbody> ().AddExplosionForce (explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
				}
			}
		}
	}
}