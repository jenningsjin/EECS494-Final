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
        if (GameResults.S.result_ddr1 == 0) {
            GameResults.S.result_ddr1 = 1;
            GameResults.S.dialogue_spot = 8;
        }
        else if (GameResults.S.result_ddr2 == 0) {
            GameResults.S.result_ddr2 = 1;
            GameResults.S.dialogue_spot = 9;
        }
        SceneManager.LoadScene("DialogueScene_Plumber");
    }
}
