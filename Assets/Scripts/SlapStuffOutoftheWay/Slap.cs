using UnityEngine;
using System.Collections;

public class Slap : MonoBehaviour {
    Vector3 next = new Vector3(180, 0, 0);
    public static int slapping = 0;
    float time = 0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space) && slapping == 0)
        {
            slapping = 1;
        }
        if (slapping == 1)//Slap
        {
            next.y += 8f;
            if (next.y >= 120f)
            {
                slapping = 2;
            }
        } else if(slapping == 2)//Return to original position
        {
            next.y -= 4f;
            if (next.y <= 0)
            {
                slapping = 3;
                time = 0;
            }
        } else if(slapping == 3)
        {
            time += Time.deltaTime;
            if(time >= 0.2f)
            {
                slapping = 0;
            }
        }

        this.transform.eulerAngles = next;
        //180, 120, 0
    }


    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }
}
