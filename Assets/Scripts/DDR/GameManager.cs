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

    public Flowchart flowchart;

    public bool gamePlayed = false;
    public int gameResult = 0;

    void Start() { 
        Debug.Log("Start");
        gamePlayed = GameResults.S.gamePlayed;
        gameResult = GameResults.S.gameResult;
        flowchart.SetBooleanVariable("gamePlayed", gamePlayed);
        flowchart.SetIntegerVariable("gameResult", gameResult);
        flowchart.enabled = true;
        if (gamePlayed) {
            if (gameResult > 0) {
                //switch to flowchart
            }
        }
    }

    void Update() {
        //gamePlayed = GameResults.S.gamePlayed;
        //gameResult = GameResults.S.gameResult;
        //flowchart.SetBooleanVariable("gamePlayed", gamePlayed);
        //flowchart.SetIntegerVariable("gameResult", gameResult);
        if (gamePlayed) {
            if (gameResult > 0) {
                //switch to flowchart
            }
        }
    }

    void sceneChange() {
        print("HI");
        SceneManager.LoadScene("DDR");
    }

    void returnToLevelSelect() {
        print("Return to level select");
        SceneManager.LoadScene("LevelSelectScene");
    }



}
