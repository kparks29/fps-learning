using UnityEngine;
using System.Collections;

namespace FPSLearning {
	public class GrenadeExplosion : MonoBehaviour {

		private Collider[] hitColliders;
		public float blastRadius;

		void OnCollisionEnter (Collision collision) {
			ExplosionWork (collision.contacts [0].point);
			Destroy (gameObject);
		}

		void ExplosionWork (Vector3 explosionPoint) {
			hitColliders = Physics.OverlapSphere (explosionPoint, blastRadius);

			foreach (Collider hitCollider in hitColliders) {
				Debug.Log (hitCollider.gameObject.name);
			}
		}
	}
}