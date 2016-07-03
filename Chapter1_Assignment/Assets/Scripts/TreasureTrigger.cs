using UnityEngine;
using System.Collections;

public class TreasureTrigger : MonoBehaviour {

	private EventManager eventManagerScript;

	void Start () {
		SetInitialReferences ();
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			gameObject.SetActive (false);
			eventManagerScript.CallOpenTreasure ();
		}
	}

	void SetInitialReferences () {
		eventManagerScript = GameObject.Find ("GameManager").GetComponent<EventManager> ();
	}
}
