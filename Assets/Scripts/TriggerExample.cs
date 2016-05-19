using UnityEngine;
using System.Collections;

namespace FPSLearning {
	
	public class TriggerExample : MonoBehaviour {

		private WalkThroughWall walkThroughWallScript;

		void OnTriggerEnter (Collider other) {
			Debug.Log (other.name + " has entered");
			walkThroughWallScript.SetLayerToNotSolid ();
		}

		void OnTriggerExit (Collider other) {
			Debug.Log (other.name + " has exited");
			walkThroughWallScript.SetLayerToDefault ();
		}

//		void OnTriggerStay (Collider other) {
//			Debug.Log (other.name + " is in the trigger");
//		}

		void SetInitialReferences () {
			if (GameObject.Find ("Wall") != null) {
				walkThroughWallScript = GameObject.Find ("Wall").GetComponent<WalkThroughWall> ();
			}
		}

		void Start () {
			SetInitialReferences ();
		}
	}
}