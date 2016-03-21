using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {
    public GameObject explosion;
    Rigidbody rigid;
    // Use this for initialization
    void Start () {
        rigid = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Character" && Slap.slapping == 1)
        {
            print(collision.gameObject.name);
            explosion.transform.position = collision.transform.position;
            Instantiate<GameObject>(explosion);
        }
        if(collision.gameObject.name != "Terrain")
        {
            rigid.constraints = RigidbodyConstraints.None;
        }
    }
}
