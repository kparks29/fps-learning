using UnityEngine;
using System.Collections;

namespace FPSLearning {
	
	public class ThrowGrenade : MonoBehaviour {

		public GameObject grenadePrefab;
		private Transform myTransform;

		// Use this for initialization
		void Start () {
			SetInitialReferences ();
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetButtonDown ("Fire1")) {
				SpawnGrenade ();
			}
		}

		void SetInitialReferences () {
			myTransform = transform;
		}

		void SpawnGrenade () {
			GameObject grenade = (GameObject) Instantiate (grenadePrefab, myTransform.TransformPoint (0, 0, 0.5f), myTransform.rotation);
			Destroy (grenade, 10);
		}
	}
}
