using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vel = this.transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            print("HI");
            vel.z += 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vel.z -= 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x -= 1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x += 1f;
        }
        this.transform.position = vel;
	}
}
