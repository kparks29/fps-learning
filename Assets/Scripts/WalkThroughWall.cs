using UnityEngine;
using System.Collections;

namespace FPSLearning {

	public class WalkThroughWall : MonoBehaviour {

		private Color myColor = new Color(0.5f, 1, 0.5f, 0.3f); 

//		void OnEnable () {
//			gameObject.layer = LayerMask.NameToLayer ("Not Solid");
//		}
//
//		void OnDisable () {
//			gameObject.layer = LayerMask.NameToLayer ("Default");
//		}

		public void SetLayerToNotSolid () {
			gameObject.layer = LayerMask.NameToLayer ("Not Solid");
			GetComponent<Renderer> ().material.SetColor("_Color", myColor);
		}

		public void SetLayerToDefault () {
			gameObject.layer = LayerMask.NameToLayer ("Default");
			GetComponent<Renderer> ().material.color = Color.white;
		}
	}
}
