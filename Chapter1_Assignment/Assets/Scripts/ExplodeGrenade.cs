using UnityEngine;
using System.Collections;

public class ExplodeGrenade : MonoBehaviour {

	private GameObject grenade;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		SetInitialReferences ();
		StartCoroutine (Explode ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Explode () {
		yield return new WaitForSeconds(2);
		Debug.Log ("BOOM!");
		GameObject explosionObj = (GameObject) Instantiate (explosion, grenade.transform.position, Quaternion.identity);
		Destroy (grenade);
		yield return new WaitForSeconds (1);
		Destroy (explosionObj);
	}

	void SetInitialReferences () {
		grenade = gameObject;
	}
}
