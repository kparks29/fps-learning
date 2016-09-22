using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace FPS {
	public class MainMenu : MonoBehaviour {

		public void PlayGame () {
			SceneManager.LoadScene ("Chapter2");
		}

		public void ExitGame () {
			Application.Quit ();
		}
	}
}