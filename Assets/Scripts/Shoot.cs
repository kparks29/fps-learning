using UnityEngine;
using System.Collections;

namespace FPSLearning
{
	public class Shoot : MonoBehaviour
	{

		private RaycastHit hit;
		private float nextFire;
		private float rate = 0.3f;
		private float range = 300;

		// Use this for initialization
		void Start ()
		{
		
		}
		
		// Update is called once per frame
		void Update ()
		{
			CheckForInput ();
		}

		void CheckForInput ()
		{
			if (Input.GetButton ("Fire1") && Time.time > nextFire)
			{
				nextFire = Time.time + rate;

				if (Physics.Raycast (transform.position, transform.forward, out hit, range))
				{
					if (hit.transform.CompareTag ("Enemy"))
					{
						Debug.Log ("Enemy " + hit.transform.name + " hit");
					}
				}
			}
		}
	}
}