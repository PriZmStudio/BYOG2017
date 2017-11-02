using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    int doOnce = 0;

    string []levels = {"Retention", "I. Steps", "II. Hurt", "III. Fly", "IV. Teamwork", "V. Fall" };

	// Use this for initialization
	void Start () {
        //int currentLevel = SceneManager.GetActiveScene().buildIndex;
        GetComponent<TextMeshProUGUI>().text = levels[getIndex()];
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

    int getIndex()
    {
        string levelName = SceneManager.GetActiveScene().name;
        if (levelName.Equals("intro"))
            return 0;
        if (levelName.Equals("level01"))
            return 1;
        if (levelName.Equals("level02"))
            return 2;
        if (levelName.Equals("level03"))
            return 3;
        if (levelName.Equals("level04"))
            return 4;
        if (levelName.Equals("level05"))
            return 5;
        return -1;
    }
}
