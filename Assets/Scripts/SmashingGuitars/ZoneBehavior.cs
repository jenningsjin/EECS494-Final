using UnityEngine;
using System.Collections;

public class ZoneBehavior : MonoBehaviour {
    public bool isZone = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        if (!isZone)
        {
            print("Collected");
            ControlAvatar.collected = 1;
        } else if(ControlAvatar.collected == 2 && isZone)
        {
            ControlAvatar.collected = 3;
        }
        print(collision.gameObject.name);
    }
}
