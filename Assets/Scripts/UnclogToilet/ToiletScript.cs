using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToiletScript : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject toiletCamera;
	public GameObject plunger;
	public GameObject scorePanel;
	public GameObject timerPanel;
	public GameObject player;

	//public delegate void MeetPlumber();
	//public static event MeetPlumber m;

	// Use this for initialization
	void Start () {
		mainCamera.GetComponent<Camera> ().enabled = true;
		mainCamera.GetComponent<AudioListener> ().enabled = true;
		mainCamera.GetComponent<AudioSource> ().enabled = true;
		toiletCamera.GetComponent<Camera> ().enabled = false;
		toiletCamera.GetComponent<AudioListener> ().enabled = false;
		toiletCamera.GetComponent<AudioSource> ().enabled = false;
		plunger.SetActive (false);
		scorePanel = GameObject.Find ("ScorePanel");
		scorePanel.SetActive (false);
		timerPanel = GameObject.Find ("TimerPanel");
		timerPanel.SetActive (false);
		player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.CompareTag ("Player")) {
			Debug.Log ("This is a player");
			// Start the dialogue and freeze player motion
			Fungus.Flowchart.BroadcastFungusMessage("MeetPlumber");
			c.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		}
	}

	public void displayInstructions() {
		Debug.Log ("Starting the game...");
		mainCamera.GetComponent<Camera> ().enabled = false;
		mainCamera.GetComponent<AudioListener> ().enabled = false;
		mainCamera.GetComponent<AudioSource> ().enabled = false;
		toiletCamera.GetComponent<Camera> ().enabled = true;
		toiletCamera.GetComponent<AudioListener> ().enabled = true;
		toiletCamera.GetComponent<AudioSource> ().enabled = true;
		player.SetActive (false);
		scorePanel.SetActive (true);
		timerPanel.SetActive (true);
	}

	public void playGame() {
		plunger.SetActive (true);
	}

	public void notPlaying() {
		Debug.Log ("Not playing...");
		GameObject go = GameObject.Find ("Player");
		go.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
	}

	public void restoreState() {
		mainCamera.GetComponent<Camera> ().enabled = true;
		mainCamera.GetComponent<AudioListener> ().enabled = true;
		mainCamera.GetComponent<AudioSource> ().enabled = true;
		toiletCamera.GetComponent<Camera> ().enabled = false;
		toiletCamera.GetComponent<AudioListener> ().enabled = false;
		toiletCamera.GetComponent<AudioSource> ().enabled = false;
		plunger.SetActive (false);
		scorePanel = GameObject.Find ("ScorePanel");
		scorePanel.SetActive (false);
		timerPanel = GameObject.Find ("TimerPanel");
		timerPanel.SetActive (false);
		player.SetActive (true);
	}

	public void loadLevelSelect() {
		SceneManager.LoadScene ("LevelSelectScene");
	}
}
