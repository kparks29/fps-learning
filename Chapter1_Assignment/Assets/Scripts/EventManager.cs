using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void GeneralEvent ();
	public event GeneralEvent openTreasureEvent;
	public AudioClip audioClip;
	private AudioSource audioSource;
	private Light lighting;
	private string originalColor;
	private Color darkColor = new Color ();

	public void CallOpenTreasure () {
		if (openTreasureEvent != null) {
			ColorUtility.TryParseHtmlString ("#656146FF", out darkColor);
			openTreasureEvent ();

			// change color
			RenderSettings.ambientIntensity = 0;
			RenderSettings.skybox = null;
			lighting.color = darkColor;

			// play audio
			audioSource.time = 11f;
			audioSource.clip =  audioClip;
			audioSource.Play ();
		}
	}

	void Start () {
		audioSource = GameObject.Find ("FPSController").GetComponent<AudioSource> ();
		lighting = GameObject.Find ("Directional light").GetComponent<Light> ();
	}
}
