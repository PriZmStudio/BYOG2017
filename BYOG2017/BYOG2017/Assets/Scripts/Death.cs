using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {
    
    Door door;
    
	// Use this for initialization
	void Start () {
        door = GameObject.Find("door").GetComponent<Door>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -10.0f && !door.won) {
            KillPlayer();
        }		
	}

    public static void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
