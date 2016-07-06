using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Chapter2 {
	public class MainMenu : MonoBehaviour {

		public void PlayGame () {
			SceneManager.LoadScene ("Chapter2");
		}

		public void ExitGame () {
			Application.Quit ();
		}
	}
}