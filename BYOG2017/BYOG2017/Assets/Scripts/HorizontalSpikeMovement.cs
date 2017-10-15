using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HorizontalSpikeMovement : MonoBehaviour {

    float animationTime = 2.0f;
    bool movingLeft = false;

    [SerializeField]
    float fromX, toX;

	// Use this for initialization
	void Start () {
        StartCoroutine(Move());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Move()
    {
        transform.DOMoveX(movingLeft ? fromX : toX, animationTime);
        yield return new WaitForSeconds(animationTime);
        movingLeft = !movingLeft;
        StartCoroutine(Move());
    }
}
