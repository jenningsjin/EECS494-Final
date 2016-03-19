using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {
	enum Moves {Paper, Rock, Scissors};
	GameObject PlayerMove;
	GameObject EnemyMove;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void getPlayerMove ( int Move ) {
		if (Move == (int)Moves.Paper) {
			print("Paper");
		}

		else if (Move == (int)Moves.Rock) {
			print("Rock");
		}

		else if (Move == (int)Moves.Scissors) {
			print("Scissors");
		}

		else {
			print("Nothing selected");
		}

		PlayerMove = GameObject.FindWithTag("Player");
		EnemyMove = GameObject.FindWithTag("Enemy");


//		Vector2 transformVector = Vector2(2f, 0f);
		PlayerMove.transform.Translate(Time.deltaTime * Vector2.up);
		//print(PlayerMove.name);
	}
}
