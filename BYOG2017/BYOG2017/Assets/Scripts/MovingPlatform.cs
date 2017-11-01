using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour {

    [SerializeField]
    bool movingUp = true;

    [SerializeField]
    float animationTime = 2.0f, fromY = 2.0f, toY = -2.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine(Animate());
    }
	
	// Update is called once per frame
	void Update () {
        //
	}

    IEnumerator Animate()
    {
        transform.DOMoveY(movingUp ? fromY : toY, animationTime);
        yield return new WaitForSeconds(animationTime + 0.5f);
        movingUp = !movingUp;
        StartCoroutine(Animate());
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") {
            coll.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.transform.parent = null;
        }
    }
}
