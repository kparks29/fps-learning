using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Chapter1_Assignment {
	public class CanvasManager : MonoBehaviour {

		private EventManager eventManagerScript;
		public GameObject panel;
		public Text title;
		public Text message;

		void OnEnable () {
			SetInitialReferences ();
			eventManagerScript.openTreasureEvent += SetTrickedMessage;
			eventManagerScript.winEvent += SetWinMessage;
		}

		void OnDisable () {
			eventManagerScript.openTreasureEvent -= SetTrickedMessage;
			eventManagerScript.winEvent += SetWinMessage;
		}

		void Start () {
			StartCoroutine (DisableCanvas ());
		}

		IEnumerator DisableCanvas () {
			yield return new WaitForSeconds (4);
			panel.SetActive (false);
		}

		void SetTrickedMessage () {
			panel.SetActive (true);
			title.text = "Foolish Adventurer!";
			message.text = "Now you shall suffer...";
			StartCoroutine (DisableCanvas ());
		}

		void SetWinMessage () {
			panel.SetActive (true);
			title.text = "NOOOO!";
			message.text = "I have been defeated";
			StartCoroutine (DisableCanvas ());
		}

		void SetInitialReferences () {
			eventManagerScript = GameObject.Find ("GameManager").GetComponent<EventManager> ();
		}

	}
}