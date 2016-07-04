using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void GeneralEvent ();
	public event GeneralEvent openTreasureEvent;
	public event GeneralEvent winEvent;
	public AudioClip audioClip;
	private AudioSource audioSource;
	private Light lighting;
	private Color originalColor;
	private Color darkColor = new Color ();
	private int enemyCount = 0;
	private Material originalSkybox;
	private float originalIntensity;

	public void CallOpenTreasure () {
		if (openTreasureEvent != null) {
			ColorUtility.TryParseHtmlString ("#656146FF", out darkColor);
			openTreasureEvent ();

			// change color
			RenderSettings.ambientIntensity = 0;
			RenderSettings.skybox = null;
			lighting.color = darkColor;

			// play audio
			audioSource.clip =  audioClip;
			audioSource.time = 11f;
			audioSource.Play ();
		}
	}

	public void RemoveObject (GameObject obj, float delay) {
		StartCoroutine (RemoveObjectDelay (obj, delay));
	}

	IEnumerator RemoveObjectDelay (GameObject obj, float delay) {
		yield return new WaitForSeconds(delay);
		Destroy (obj);
	}

	void Awake () {
		audioSource = GameObject.Find ("FPSController").GetComponent<AudioSource> ();
		lighting = GameObject.Find ("Directional light").GetComponent<Light> ();
		originalColor = lighting.color;
		originalSkybox = RenderSettings.skybox;
		originalIntensity = RenderSettings.ambientIntensity;
	}

	public void AddEnemies (int count) {
		enemyCount += count;
	}

	public void RemoveEnemies (int count) {
		enemyCount -= count;
		if (enemyCount == 0) {
			EndOfGame ();
		}
	}

	void EndOfGame () {
		if (winEvent != null) {
			winEvent ();
			// reset color
			RenderSettings.ambientIntensity = originalIntensity;
			RenderSettings.skybox = originalSkybox;
			lighting.color = originalColor;

			// stop audio
			audioSource.Stop ();
		}
	}
}
