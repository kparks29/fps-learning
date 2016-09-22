﻿using UnityEngine;
using System.Collections;


namespace FPS {
	public class GameManager_ToggleMenu : MonoBehaviour {

		private GameManager_Master gameManagerMaster;
		public GameObject menu;

		void Start () {
			ToggleMenu();
		}

		void Update () {
			CheckForMenuToggleRequest();
		}

		void OnEnable () {
			SetInitialReferences();
			gameManagerMaster.GameOverEvent += ToggleMenu;
		}

		void OnDisable () {
			gameManagerMaster.GameOverEvent -= ToggleMenu;
		}

		void SetInitialReferences () {
			gameManagerMaster = GetComponent<GameManager_Master>();
		}

		void CheckForMenuToggleRequest () {
			if (Input.GetKeyUp (KeyCode.Escape) && !gameManagerMaster.isGameOver && !gameManagerMaster.isInventoryUIOn) {
				ToggleMenu ();
			}
		}

		void ToggleMenu () {
			if (menu != null) {
				menu.SetActive (!menu.activeSelf);
				gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
				gameManagerMaster.CallEventMenuToggle ();
			} else {
				Debug.LogWarning ("You need to assign a UI GameObject to the Toggle Menu script in the inspector.");
			}
		}
	}
}