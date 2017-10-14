using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Memory : MonoBehaviour {

    bool isCaptured;
    SpriteRenderer spriteRenderer;
    BoxCollider2D coll;

	// Use this for initialization
	void Start () {
        isCaptured = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    public bool isMemoryCaptured()
    {
        return isCaptured;
    }

    public void captureMemory()
    {
        isCaptured = true;
        spriteRenderer.enabled = false;
        coll.enabled = false;
        Door.collectedMemories.Add(this);
    }

    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.tag == "Player") {
            captureMemory();
        }
    }
}
