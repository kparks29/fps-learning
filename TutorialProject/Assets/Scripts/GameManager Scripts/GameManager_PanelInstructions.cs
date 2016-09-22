using UnityEngine;
using System.Collections;

namespace FPS 
{
	public class GameManager_PanelInstructions : MonoBehaviour 
	{
		public GameObject panelInstructions;
		private GameManager_Master gameManagerMaster;

		void OnEnable () 
		{
			SetInitialReferences ();
			gameManagerMaster.GameOverEvent += TurnOffPanelInstructions;
		}

		void OnDisable () 
		{
			gameManagerMaster.GameOverEvent -= TurnOffPanelInstructions;
		}

		void SetInitialReferences () 
		{
			gameManagerMaster = GetComponent<GameManager_Master> ();
		}

		void TurnOffPanelInstructions () 
		{
			if (panelInstructions != null) 
			{
				panelInstructions.SetActive (false);
			} 
			else 
			{
				Debug.LogWarning ("Please set the panelInstructions to a panel in the GameManager_PanelInstructions script in the inspector.");
			}
		}
	}
}