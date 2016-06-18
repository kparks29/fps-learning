using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace Chapter1 {
	public class Welcome : MonoBehaviour {

		public Text text;
		public Canvas canvas;

		void Start () {
			text.text = "Hello World";
			canvas.gameObject.SetActive (false);
		}
	}
}