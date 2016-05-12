using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Welcome : MonoBehaviour {

	public Text text;

	void Start () {
		text.text = "Hello World";
		text.gameObject.SetActive (false);
	}
}
