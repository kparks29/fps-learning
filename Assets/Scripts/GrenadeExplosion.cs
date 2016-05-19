using UnityEngine;
using System.Collections;

namespace FPSLearning {
	public class GrenadeExplosion : MonoBehaviour {

		void OnCollisionEnter (Collision collision) {
			Debug.Log (collision.contacts [0].point.ToString ());
			Destroy (gameObject);
		}
	}
}