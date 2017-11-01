using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour {

    int i = 1;

    GameObject thePlayer;
    CameraShake cameraShake;

    // Use this for initialization
    void Start () {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        if (thePlayer == null) {
            Debug.LogError("NO PLAYER FOUND");
        }

        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        if (cameraShake == null)
        {
            Debug.LogError("No Camera Found");
        }

        transform.DORotate(new Vector3(0.0f, 0.0f, 180.0f * i), 2.0f).SetLoops(-1, LoopType.Restart);
        //StartCoroutine(Rotate());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Player" && thePlayer != null) {
            if (cameraShake != null)
                cameraShake.Shake(0.1f, 0.2f);
            thePlayer.GetComponent<Death>().KillPlayer();
        }
    }

    /*
    IEnumerator Rotate()
    {
        transform.DORotate(new Vector3(0.0f, 0.0f, 180.0f * i), 2.0f).SetLoops(-1, LoopType.Restart);
        yield return new WaitForSeconds(2.0f);
        i++;
        StartCoroutine(Rotate());
    }
    */
}
