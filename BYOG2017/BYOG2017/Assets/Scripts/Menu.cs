using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        string currentScene = SceneManager.GetActiveScene().name;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentScene.Equals("intro"))
                Application.Quit();
            else
                SceneManager.LoadScene("intro");
        }
	}
}
