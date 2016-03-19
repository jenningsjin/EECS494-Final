using UnityEngine;
using System.Collections;

public class PlungerScript : MonoBehaviour {
	// Use this for initialization
	private Vector3 startpos;
	private int state;
	private float timer;
	void Start () {
		startpos = transform.position;
		state = 0;
		timer = 0.0f;
	}
		
	void Update () {
		MovePlunger ();
	}

	void MovePlunger() {
		Vector3 endpos = new Vector3 (transform.position.x, transform.position.y - 0.1f, transform.position.z);
		switch (state) {
		case (0):
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log ("Moving plunger down --> state 1");
				++state;
			}
			break;
		case (1):
			transform.position = Vector3.Lerp (startpos, endpos, timer);
			timer += Time.deltaTime;
			if (transform.position == endpos) {
				Debug.Log ("Moving plunger up --> state 2");
				timer = 0.0f;
				++state;
			}
			break;
		case (2):
			transform.position = Vector3.Lerp (endpos, startpos, timer);
			timer += Time.deltaTime;
			if (transform.position == startpos) {
				Debug.Log ("Returning to start --> state 0");
				timer = 0.0f;
				state = 0;
			}
			break;
		default:
			Debug.Log ("Undefined state");
			break;
		}
	}
}
