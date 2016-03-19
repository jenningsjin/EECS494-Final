using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
    float time = 0;
    public GameObject enemy;
    bool start = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            start = true;
        }
        if(time > 1 && start)
        {
            Vector3 pos = this.transform.position;
            pos.x += Random.Range(-0.5f, 0.5f);
            enemy.transform.position = pos;
            Instantiate<GameObject>(enemy);
            time = 0;
        }
    }
}
