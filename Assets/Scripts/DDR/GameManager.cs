using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager : MonoBehaviour {
    //public static GameManager S;

    public static GameManager S {
        get {
            if (gameInfo == null) {
                gameInfo = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameInfo.AddComponent<GameManager>();
                DontDestroyOnLoad(gameInfo);
                Debug.Log("ifstatement");

                Vector3 temp = Vector3.zero;
                temp.y = -900;
                gameInfo.transform.position += temp;

            }

            return gameInfo.GetComponent<GameManager>();
        }
    }
    
    // Use this for initialization
    static GameObject gameInfo = null;

    public Flowchart flowchart_start;
    public Flowchart flowchart_incorrect;
    public Flowchart flowchart_sad;

    public int result_joust1 = 0;
    public int result_joust2 = 0;
    public int dialogue_spot = 0; //0 start, 1 first joust, 2 second joust

    public int result_rps1 = 0;
    public int result_rps2 = 0;
    public int result_rps3 = 0;

    public int result_ddr1 = 0;
    public int result_ddr2 = 0;

    void Start() {
        GetResults();
        //flowchart_start.ExecuteBlock("Joust_Lose1");
        LocateDialogue();


        //if ()
        //flowchart_start.ExecuteBlock("Start");
        //Debug.Log("Start");
        //gamePlayed = GameResults.S.gamePlayed;
        //gameResult = GameResults.S.gameResult;
        //flowchart.SetBooleanVariable("gamePlayed", gamePlayed);
        //flowchart.SetIntegerVariable("gameResult", gameResult);
        //flowchart.enabled = true;
        //if (gamePlayed) {
        //    if (gameResult > 0) {
        //        //switch to flowchart
        //    }
        //}
    }

    void Update() {
        //gamePlayed = GameResults.S.gamePlayed;
        //gameResult = GameResults.S.gameResult;
        //flowchart.SetBooleanVariable("gamePlayed", gamePlayed);
        //flowchart.SetIntegerVariable("gameResult", gameResult);
        //if (gamePlayed) {
        //    if (gameResult > 0) {
        //        //switch to flowchart
        //    }
        //}
    }

    void StartJoust() {
        SceneManager.LoadScene("Joust");
    }

    void StartRPS() {
        SceneManager.LoadScene("RPS");
    }

    void StartSlap() {
        SceneManager.LoadScene("SlapStuffOutoftheWay");
    }

    void StartDDR() {
        SceneManager.LoadScene("DDR");
    }

    void StartUnclog() {
        SceneManager.LoadScene("UnclogToilet");
    }

    void GetResults() {
        dialogue_spot = GameResults.S.dialogue_spot;

        result_joust1 = GameResults.S.result_joust1;
        result_joust2 = GameResults.S.result_joust2;

        result_rps1 = GameResults.S.result_rps1;
        result_rps2 = GameResults.S.result_rps2;
        result_rps3 = GameResults.S.result_rps3;

        result_ddr1 = GameResults.S.result_ddr1;
        result_ddr2 = GameResults.S.result_ddr2;
    }

    void LocateDialogue() {
        switch (dialogue_spot) {
            case 0: // start game from beginning
                Debug.Log("Case 0");
                flowchart_start.ExecuteBlock("Start");
                break;
            case 1: //finished one jousting game
                Debug.Log("Case 1");
                if (result_joust1 == 1) { //win
                    Debug.Log("Case 1-w");
                    flowchart_start.ExecuteBlock("Joust_Win1");
                }
                else if (result_joust1 == -1) {
                    Debug.Log("Case 1-l");
                    flowchart_start.ExecuteBlock("Joust_Lose1");
                }
                break;
            case 2: //finished both jousting games
                Debug.Log("Case 2");
                if (result_joust2 == 1) {
                    flowchart_start.ExecuteBlock("Joust_Win2");
                }
                else if (result_joust2 == -1) {
                    flowchart_start.ExecuteBlock("Joust_Lose2");
                }
                break;
            case 3: //finished first rps game
                Debug.Log("Case 3");
                if (result_rps1 == 1) {
                    flowchart_start.ExecuteBlock("RPS_Win1");
                }
                else if (result_rps1 == -1) {
                    flowchart_start.ExecuteBlock("RPS_Lose1");
                }
                break;
            case 4: //finished second rps game
                if (result_rps2 == 1) {
                    flowchart_start.ExecuteBlock("RPS_Win2");
                }
                else if (result_rps2 == -1) {
                    flowchart_start.ExecuteBlock("RPS_Lose2");
                }
                break;
            case 5: //finished third rps game
                if (result_rps3 == 1) {
                    flowchart_start.ExecuteBlock("RPS_Win3");
                }
                else if (result_rps3 == -1) {
                    flowchart_start.ExecuteBlock("RPS_Lose3");
                }
                break;
            case 6:
                flowchart_incorrect.ExecuteBlock("SlapWL_1");
                break;
            case 7:
                flowchart_incorrect.ExecuteBlock("SlapWL_2");
                break;
            case 8:
                if (result_ddr1 == 1) {
                    flowchart_sad.ExecuteBlock("DDR_Win1");
                }
                else if (result_ddr1 == -1) {
                    flowchart_sad.ExecuteBlock("DDR_Lose1");
                }
                break;
            case 9:
                flowchart_sad.ExecuteBlock("DDR_WL2");
                break;
        }
    }


}
