using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuCharacter : MonoBehaviour {
    GameObject mainCharacter;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Main Camera")
        {
            SceneManager.LoadScene("Date Menu");
        }
    }

}
