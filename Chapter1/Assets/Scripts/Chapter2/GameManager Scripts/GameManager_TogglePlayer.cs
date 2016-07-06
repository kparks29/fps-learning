using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;


namespace Chapter2 {
	public class GameManager_TogglePlayer : MonoBehaviour {

		public FirstPersonController playerController;
		private GameManager_Master gameManagerMaster;

		void OnEnable () {
			SetInitialReferences ();
			gameManagerMaster.MenuToggleEvent += TogglePlayerController;
			gameManagerMaster.InventoryUIToggleEvent += TogglePlayerController;
		}

		void OnDisable () {
			gameManagerMaster.MenuToggleEvent -= TogglePlayerController;
			gameManagerMaster.InventoryUIToggleEvent -= TogglePlayerController;
		}

		void SetInitialReferences () {
			gameManagerMaster = GetComponent<GameManager_Master> ();
		}

		void TogglePlayerController () {
			if (playerController != null) {
				playerController.enabled = !playerController.enabled;
			} else {
				Debug.LogWarning ("First Person Controller not set on Toggle Player script in inspector.");
			}
		}
	}
}