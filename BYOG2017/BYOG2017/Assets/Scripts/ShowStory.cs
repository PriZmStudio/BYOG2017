using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class ShowStory : MonoBehaviour {

    [SerializeField]
    string story;

    [SerializeField]
    TextMeshProUGUI playerStory;

    int doOnceEnter = 0;
    int doOnceExit = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && doOnceEnter == 0) {
            doOnceEnter++;
            playerStory.alpha = 0.0f;
            playerStory.DOFade(1.0f, 1.0f);
            playerStory.text = story;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player" && doOnceExit == 0)
        {
            doOnceExit++;
            playerStory.DOFade(0.0f, 1.0f);
            StartCoroutine(turnOff());
        }
    }

    IEnumerator turnOff()
    {
        yield return new WaitForSeconds(1.0f);
        playerStory.text = "";
    }
}
