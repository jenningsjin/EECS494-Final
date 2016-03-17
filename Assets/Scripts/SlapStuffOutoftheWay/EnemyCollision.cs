using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {
    public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Character" && Slap.slapping != 0)
        {
            print(collision.gameObject.name);
            explosion.transform.position = collision.transform.position;
            Instantiate<GameObject>(explosion);
        }
    }
}
