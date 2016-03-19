using UnityEngine;
using System.Collections;

public class ToiletScript : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject toiletCamera;
	public GameObject plunger;
	public GameObject scorePanel;

	// Use this for initialization
	void Start () {
		mainCamera.GetComponent<Camera> ().enabled = true;
		mainCamera.GetComponent<AudioListener> ().enabled = true;
		toiletCamera.GetComponent<Camera> ().enabled = false;
		toiletCamera.GetComponent<AudioListener> ().enabled = false;
		plunger.SetActive (false);
		scorePanel = GameObject.Find ("ScorePanel");
		scorePanel.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.CompareTag("Player")) {
			Debug.Log("This is a player");
			mainCamera.GetComponent<Camera> ().enabled = false;
			mainCamera.GetComponent<AudioListener> ().enabled = false;
			toiletCamera.GetComponent<Camera> ().enabled = true;
			toiletCamera.GetComponent<AudioListener> ().enabled = true;
			c.gameObject.SetActive (false);
			plunger.SetActive (true);
			scorePanel.SetActive (true);
		}
	}
}
