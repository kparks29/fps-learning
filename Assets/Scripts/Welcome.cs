using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Welcome : MonoBehaviour {

	public Text text;
	public Canvas canvas;

	void Start () {
		text.text = "Hello World";
		canvas.gameObject.SetActive (false);
	}
}
