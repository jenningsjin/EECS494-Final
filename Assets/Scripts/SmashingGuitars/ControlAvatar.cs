using UnityEngine;
using System.Collections;

public class ControlAvatar : MonoBehaviour {
    Rigidbody rigid;
    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;
    public GameObject zone4;
    public GameObject pile;
    public GameObject guitar;
    public static int collected = 0;
    int currentZone = 0;

    // Use this for initialization
    void Start () {
        rigid = GetComponentInChildren<Rigidbody>();
        zone1.SetActive(false);
        zone2.SetActive(false);
        zone3.SetActive(false);
        zone4.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.AddForce(Vector3.left * 10f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.AddForce(Vector3.right * 10f);
        }
        if(collected == 1)
        {
            //Randomly pick a zone.
            currentZone = (int) Random.Range(1f, 4.9f);
            if(currentZone == 1)
            {
                zone1.SetActive(true);
            } else if(currentZone == 2)
            {
                zone2.SetActive(true);
            } else if(currentZone == 3)
            {
                zone3.SetActive(true);
            } else if(currentZone == 4)
            {
                zone4.SetActive(true);
            }
            collected = 2;
        }
        if(collected == 3)
        {
            //Smash Guitar
            collected = 4;
        }
        if(collected == 4)
        {
            if (currentZone == 1)
            {
                zone1.SetActive(false);
            }
            else if (currentZone == 2)
            {
                zone2.SetActive(false);
            }
            else if (currentZone == 3)
            {
                zone3.SetActive(false);
            }
            else if (currentZone == 4)
            {
                zone4.SetActive(false);
            }
            collected = 0;
        }
	}
}
