using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    int doOnce = 0;

    string []levels = {"Retention", "II. Hurt", "III. Fly", "IV. Teamwork", "V. Fall" };

	// Use this for initialization
	void Start () {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        GetComponent<TextMeshProUGUI>().text = levels[currentLevel];
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && doOnce == 0) {
            doOnce++;
            Fade();
        }
	}

    void Fade()
    {
        GetComponent<TextMeshProUGUI>().DOFade(0.0f, 2.0f);
    }
}
