using UnityEngine;
using System.Collections;

public class GameResults : MonoBehaviour {

    public static GameResults S {
        get {
            if (gameInfo == null) {
                gameInfo = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameInfo.AddComponent<GameResults>();
                DontDestroyOnLoad(gameInfo);
                Debug.Log("ifstatement");

                Vector3 temp = Vector3.zero;
                temp.y = -900;
                gameInfo.transform.position += temp;

            }

            return gameInfo.GetComponent<GameResults>();
        }
    }

    // Use this for initialization
    static GameObject gameInfo = null;
    public int result_joust1 = 0;
    public int result_joust2 = 0;
    public int dialogue_spot = 0;

    public int result_rps1 = 0;
    public int result_rps2 = 0;
    public int result_rps3 = 0;
}
