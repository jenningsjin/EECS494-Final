using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterMotion : MonoBehaviour {
    Rigidbody rigid;
    public bool start = false;
    public float timer = 60f;
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
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                timer = 0;
                //Lost game
                EndGame();
            }
            if(this.rigid.velocity.z < 16f)
            {
                rigid.AddForce(Vector3.forward * 10f);
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 30f, 10f, 60f, 20f), " " + timer.ToString("0.00") + " s");
    }
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject.name == "End")
        {
            //Won Game
            EndGame();
        }
    }

    void EndGame() {
        if (GameResults.S.result_slap1 == 0) { // increment to 6 (after first slap game)
            GameResults.S.result_slap1 = 1;
            GameResults.S.dialogue_spot = 6;
        }
        else if (GameResults.S.result_slap2 == 0) {
            GameResults.S.result_slap2 = 1;
            GameResults.S.dialogue_spot = 7;
        }
        else {
            Debug.Log("Problem with Slapping game EndGame()");
        }
        SceneManager.LoadScene("DialogueScene_Plumber");
    }

}
