using UnityEngine;
using System.Collections;

public class ShootGrenade : MonoBehaviour {

	public GameObject grenadePrefab;
	private float speed = 10;
	private Transform gunTransform;

	// Use this for initialization
	void Start () {
		SetInitialReferences ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckForInput ();
	}

	void CheckForInput () {
		if (Input.GetButtonDown ("Fire1")) {
			GameObject grenade = (GameObject) Instantiate (grenadePrefab, gunTransform.TransformPoint(0, 1.8f, 0), gunTransform.rotation);
			grenade.GetComponent<Rigidbody>().AddForce (gunTransform.up * speed, ForceMode.Impulse);
		}
	}

	void SetInitialReferences () {
		gunTransform = transform;
	}
}
