using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_1 : MonoBehaviour {

    GameObject camera;

	// Use this for initialization
	void Start () {
        camera = GameObject.Find("Camera");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player") {
            camera.GetComponent<Fading>().BeginFade(1);
            StartCoroutine(nextLevel());
        }
    }

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("level01");
    }
}
