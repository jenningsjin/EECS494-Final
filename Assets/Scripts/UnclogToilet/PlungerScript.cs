﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlungerScript : MonoBehaviour {
	// Use this for initialization
	private Vector3 startpos;
	private int state;
	private float lerpTimer; // timer for plunger movement
	public int score;
	public Text scoreGUI;
	public float timer; // count down timer
	public Text timerGUI;

	void Start () {
		startpos = transform.position;
		state = 0;
		lerpTimer = 0.0f;
		score = 0;
		timer = 11;
		GameObject tmp1 = GameObject.Find ("ScoreText");
		GameObject tmp2 = GameObject.Find ("TimerText");
		if (!tmp1 || !tmp2) {
			Debug.Log("MISSING GUI!");
		}
		scoreGUI = tmp1.GetComponent<Text> ();
		timerGUI = tmp2.GetComponent<Text> ();
	}
		
	void Update () {
		UpdateTime ();
		MovePlunger ();
	}

	void UpdateTime () {
		if (timer < 0) {
			timerGUI.text = "Time's Up!!!";
		} else {
			timerGUI.text = ((int)timer).ToString();
		}
		timer = timer - Time.deltaTime;
	}

	void MovePlunger() {
		Vector3 endpos = new Vector3 (transform.position.x, transform.position.y - 0.1f, transform.position.z);
		switch (state) {
		case (0):
			if (Input.GetMouseButtonDown (0)) {
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
				++state;
			}
			break;
		case (2):
			transform.position = Vector3.Lerp (endpos, startpos, lerpTimer * 20);
			lerpTimer += Time.deltaTime;
			if (transform.position == startpos) {
				//Debug.Log ("Returning to start --> state 0");
				lerpTimer = 0.0f;
				++score;
				scoreGUI.text = "Score: " + score.ToString ();
				Debug.Log ("Your score is: " + score);
				state = 0;
			}
			break;
		default:
			Debug.Log ("Undefined state");
			break;
		}
	}
}
