using UnityEngine;
using System.Collections;

public class ControlLance : MonoBehaviour {
    Vector3 next = new Vector3(90, 0, 0);

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            next.x -= 2f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            next.x += 2f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            next.y += 2f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            next.y -= 2f;
        }
        this.transform.eulerAngles = next;
    }
}
