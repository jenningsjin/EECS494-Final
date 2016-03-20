using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlungerScript : MonoBehaviour {
	// Use this for initialization
	private Vector3 startpos;
	private int state;
	private float lerpTimer; // timer for plunger movement
	public int score;
	public Text scoreGUI;
	public float timer; // count down timer
	public Text timerGUI;
	public bool gameOver;
	public GameObject explosion;
	public float charge;
	public bool messageSent;

	void Start () {
		startpos = transform.position;
		state = 0;
		lerpTimer = 0.0f;
		score = 0;
		timer = 31;
		GameObject tmp1 = GameObject.Find ("ScoreText");
		GameObject tmp2 = GameObject.Find ("TimerText");
		if (!tmp1 || !tmp2) {
			Debug.Log("MISSING GUI!");
		}
		scoreGUI = tmp1.GetComponent<Text> ();
		timerGUI = tmp2.GetComponent<Text> ();
		gameOver = false;
		charge = 0;
		Behaviour b = (Behaviour) this.gameObject.GetComponent("Halo");
		b.enabled = false;
		messageSent = false;
	}
		
	void Update () {
		if (gameOver) {
			PauseForEffect ();
		} else {
			UpdateTimer ();
			MovePlunger ();
		}
	}

	void PauseForEffect() {
		// TODO: integrate with fungus. This is just a placeholder.
		if (timer < 0 && !messageSent) {
			//SceneManager.LoadScene ("LevelSelectScene");
			Fungus.Flowchart.BroadcastFungusMessage("GameOver");
			messageSent = true;
		}
		timer -= Time.deltaTime;
	}

	void UpdateTimer () {
		if (timer < 0) {
			timerGUI.text = "Time's Up!!!";
			gameOver = true;
			timer = 2f;
		} else {
			timerGUI.text = ((int)timer).ToString();
		}
		timer = timer - Time.deltaTime;
	}

	void MovePlunger() {
		Vector3 endpos = new Vector3 (transform.position.x, transform.position.y - 0.1f, transform.position.z);
		switch (state) {
		case (0):
			if (Input.GetKey(KeyCode.Space)) {
				Debug.Log (charge);
				charge += Time.deltaTime;
				if (charge >= 3) {
					Behaviour b = (Behaviour) this.gameObject.GetComponent ("Halo"); // Downcast
					b.enabled = true;
				}
			}
			if (Input.GetKeyUp(KeyCode.Space)) {
				//Debug.Log ("Moving plunger down --> state 1");
				++state;
			}
			break;
		case (1):
			transform.position = Vector3.Lerp (startpos, endpos, lerpTimer * 20);
			lerpTimer += Time.deltaTime;
			if (transform.position == endpos) {
				//Debug.Log ("Moving plunger up --> state 2");
				lerpTimer = 0.0f;
				if (charge >= 3) {
					Behaviour b = (Behaviour)this.gameObject.GetComponent ("Halo");
					b.enabled = false;
					explosion.transform.position = transform.position;
					Instantiate<GameObject> (explosion);
				}
				++state;
			}
			break;
		case (2):
			transform.position = Vector3.Lerp (endpos, startpos, lerpTimer * 20);
			lerpTimer += Time.deltaTime;
			if (transform.position == startpos) {
				//Debug.Log ("Returning to start --> state 0");
				lerpTimer = 0.0f;
				if (charge >= 3) {
					score += 10;
				} else {
					++score;
				}
				scoreGUI.text = "Score: " + score.ToString ();
				Debug.Log ("Your score is: " + score);
				state = 0;
				// You need to recharge after releasing the plunger
				charge = 0;
			}
			break;
		default:
			Debug.Log ("Undefined state");
			break;
		}
	}

	// Called by Fungus. Small bug where plunger automatically goes down.
	public void playAgain() {
		gameOver = false;
		score = 0;
		timer = 31;
		scoreGUI.text = "Score: " + timer.ToString ();
		messageSent = false;
	}
}
