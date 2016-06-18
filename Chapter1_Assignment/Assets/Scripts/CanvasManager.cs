using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Chapter1_Assignment {
	public class CanvasManager : MonoBehaviour {

		void Start () {
			StartCoroutine (DisableCanvas ());
		}

		IEnumerator DisableCanvas () {
			yield return new WaitForSeconds (5);
			gameObject.SetActive (false);
		}

	}
}