using UnityEngine;
using System.Collections;

namespace Chapter1
{
	public class FindEnemies : MonoBehaviour {

		GameObject[] enemies;

		// Use this for initialization
		void Start () {
			FindAllEnemies ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		void FindAllEnemies ()
		{
			enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			if (enemies.Length > 0)
			{
				foreach (GameObject enemy in enemies)
				{
					Debug.Log ("Enemy " + enemy.name + " found.");
				}
			}
		}
	}
}
