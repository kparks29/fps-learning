using UnityEngine;
using System.Collections;

public class TreasureTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			Debug.Log ("Ran into Chest");
		}
	}
}
