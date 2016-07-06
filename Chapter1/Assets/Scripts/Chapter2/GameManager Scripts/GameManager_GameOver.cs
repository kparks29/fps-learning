using UnityEngine;
using System.Collections;

namespace Chapter2 {
	public class GameManager_GameOver : MonoBehaviour {

		private GameManager_Master gameManagerMaster;
		public GameObject panelGameOver;

		void OnEnable () {
			SetInitialReferences ();
			gameManagerMaster.GameOverEvent += TurnOnGameOverPanel;
		}

		void OnDisable () {
			gameManagerMaster.GameOverEvent -= TurnOnGameOverPanel;
		}

		void SetInitialReferences () {
			gameManagerMaster = GetComponent<GameManager_Master> ();
		}

		void TurnOnGameOverPanel () {
			if (panelGameOver != null) {
				panelGameOver.SetActive (true);
			} else {
				Debug.LogWarning ("You forgot to attach a panel to the panelGameOver in the GameManager_GameOver script in the inspector.");
			}
		}
	}
}