using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour {



    // Use this for initialization
    void OnCollisionEnter(Collision c) {
        if (c.gameObject.tag == "Up") {
            Debug.Log("collision");
            WinGame();
        }
    }

    void WinGame() {
        //GameResults.S.gamePlayed = true;
        //GameResults.S.gameResult = 1;
        //Debug.Log("var1 " + GameResults.S.gamePlayed);
        //Debug.Log("var2 " + GameResults.S.gameResult);
        SceneManager.LoadScene("DialogueScene_Plumber");
    }
}
