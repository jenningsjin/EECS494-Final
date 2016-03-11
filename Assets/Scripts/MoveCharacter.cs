using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

    Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponentInChildren<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vel = new Vector3(0f, 0f, 0f);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            print("HI");
            rigid.AddForce(Vector3.forward * 30f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigid.AddForce(Vector3.back * 30f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.AddForce(Vector3.left * 30f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.AddForce(Vector3.right * 30f);
        }
        this.transform.position = rigid.transform.position;
	}
}
