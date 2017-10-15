using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotate : MonoBehaviour {

    int i = 1;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(RotateObject());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator RotateObject()
    {
        transform.DORotate(new Vector3(0.0f, 0.0f, 180.0f * i * -1), 10.0f);
        yield return new WaitForSeconds(10.0f);
        i++;
        StartCoroutine(RotateObject());
    }
}
