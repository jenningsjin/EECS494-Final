using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveKnight : MonoBehaviour {
    Rigidbody rigid;
    public bool enemy = false;
    public GameObject explosion;
    public bool start = false;
    bool end = false;
    bool win = false;
    float time = 5f;
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
            if (enemy)
            {
                rigid.AddForce(Vector3.back * 10f);
            }
            else
            {
                rigid.AddForce(Vector3.forward * 10f);
            }
        }
        if (end)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                //End game
                if (win)
                {
                    if (GameResults.S.result_joust1 == 0) 
                    {
                        //first playthrough
                        GameResults.S.result_joust1 = 1;
                        GameResults.S.dialogue_spot = 1;
                    }
                    else 
                    {
                        GameResults.S.result_joust2 = 1;
                        GameResults.S.dialogue_spot = 2;
                    }
                } else
                {
                    //lost
                    if (GameResults.S.result_joust1 == 0) {
                        //first playthrough
                        GameResults.S.result_joust1 = -1;
                        GameResults.S.dialogue_spot = 1;
                    }
                    else {
                        GameResults.S.result_joust2 = -1;
                        GameResults.S.dialogue_spot = 2;
                    }

                }
                SceneManager.LoadScene("DialogueScene_Plumber");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Main Camera")
        {
            rigid.constraints = RigidbodyConstraints.None;
            explosion.transform.position = collision.transform.position;
            Instantiate<GameObject>(explosion);
            end = true;
            win = true;
        }
        if (collision.gameObject.name == "End")
        {
            end = true;
            win = false;
        }
    }
}
