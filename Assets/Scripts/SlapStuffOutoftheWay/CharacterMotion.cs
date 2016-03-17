using UnityEngine;
using System.Collections;

public class CharacterMotion : MonoBehaviour {
    Rigidbody rigid;
    public bool start = false;
    // Use this for initialization
    void Start () {
        rigid = GetComponentInChildren<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            start = true;
        }
        if (start)
        {
            if(this.rigid.velocity.z < 16f)
            {
                rigid.AddForce(Vector3.forward * 10f);
            }
        }
    }



}
