using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void GeneralEvent ();
	public event GeneralEvent openTreasureEvent;

	public void CallOpenTreasure () {
		if (openTreasureEvent != null) {
			openTreasureEvent ();
		}
	}
}
