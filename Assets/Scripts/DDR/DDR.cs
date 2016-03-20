using UnityEngine;
using System.Collections;

public class DDR : MonoBehaviour {
    //all z = -1
    //all y = 9
    //left = -4.5
    //up = -1.5
    //down = 1.5
    //right = 4.5

    public float dropTime = 0.5f;
    float timerCounter;
    bool gameStart = false;
    float randomNum = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameStart) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                gameStart = true;
                DropArrow();
            }
        }

        if (Time.time > timerCounter) {
            DropArrow();
        }
    }
    public void DropArrow() {
        timerCounter = Time.time + dropTime;
        randomNum = Random.Range(0f, 4f);
        if (randomNum < 1) {
            //left arrow
        }
        else if (randomNum < 2) {
            //up arrow
        }
        else if (randomNum < 3) {

        }
    }
}
