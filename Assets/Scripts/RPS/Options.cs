using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {
	enum Moves {Paper, Rock, Scissors};
	GameObject PlayerMove;
	GameObject EnemyMove;
	bool textShouldBeShown = false;
	string displayMessage = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void getPlayerMove ( int Move ) {
		if (Move == (int)Moves.Paper) {
			print("Paper");
			displayMessage = "You Lost...!";
		}

		else if (Move == (int)Moves.Rock) {
			print("Rock");
			displayMessage = "You won!";
		}

		else if (Move == (int)Moves.Scissors) {
			print("Scissors");
			displayMessage = "You Lost...";
		}

		else {
			print("Nothing selected");
		}

		/*
		PlayerMove = GameObject.FindWithTag("Player");
		EnemyMove = GameObject.FindWithTag("Enemy");


		Vector2 transformVector = new Vector2(-20.0f, 0.0f);
		//print(Vector2.up);
		PlayerMove.transform.Translate(Time.deltaTime * transformVector, 0);
		*/

		//print(PlayerMove.name);
		textShouldBeShown = true;
	}


	void OnGUI() {
	    if (textShouldBeShown) {
	        GUI.Label(new Rect(10f, 10f, 100f, 50f), displayMessage  );
	    }
	}



}



