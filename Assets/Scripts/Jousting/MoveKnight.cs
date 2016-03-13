using UnityEngine;
using System.Collections;

public class MoveKnight : MonoBehaviour {
    Rigidbody rigid;
    public bool enemy = false;
    public GameObject explosion;
    // Use this for initialization
    void Start () {
        rigid = GetComponentInChildren<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (enemy)
        {
            rigid.AddForce(Vector3.back * 10f);
        }
        else
        {
            rigid.AddForce(Vector3.forward * 10f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Main Camera")
        {
            print(collision.gameObject.name);
            rigid.constraints = RigidbodyConstraints.None;
            explosion.transform.position = collision.transform.position;
            Instantiate<GameObject>(explosion);
        }
    }
}
