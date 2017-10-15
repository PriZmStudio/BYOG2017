using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour {

    int i = 1;

	// Use this for initialization
	void Start () {
        StartCoroutine(Rotate());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Player") {
            Death.KillPlayer();
        }
    }

    IEnumerator Rotate()
    {
        transform.DORotate(new Vector3(0.0f, 0.0f, 180.0f * i), 2.0f);
        yield return new WaitForSeconds(2.0f);
        i++;
        StartCoroutine(Rotate());
    }
}
