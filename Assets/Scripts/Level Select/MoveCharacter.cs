using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

    Rigidbody rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponentInChildren<Rigidbody>();
	}
	
	// FixedUpdate must be used with rigidbody.
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(rigid.velocity.z < 8f)
            {
                rigid.AddForce(Vector3.forward * 20f);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (rigid.velocity.z > -8f)
            {
                rigid.AddForce(Vector3.back * 20f);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rigid.velocity.x > -8f)
            {
                
                rigid.AddForce(Vector3.left * 20f);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (rigid.velocity.x < 8f)
            {
                rigid.AddForce(Vector3.right * 20f);
            }
        }
        this.transform.position = rigid.transform.position;
    }
}
