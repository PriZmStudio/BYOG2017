using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpChecker : MonoBehaviour {

    bool jumping;
    float jumpTime, jumpStartTime;

    CameraShake cameraShake;

	// Use this for initialization
	void Start () {
        jumping = false;
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        if (cameraShake == null)
            Debug.LogError("No camera shake component found");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !jumping) {
            jumping = true;
            jumpStartTime = Time.time;
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Platform") && jumping) {
            jumping = false;
            jumpTime = Time.time - jumpStartTime;
            if (jumpTime < 0.9f)
                cameraShake.Shake(0.05f, 0.2f);
            else
                cameraShake.Shake(0.1f, 0.2f);
        }
    }
}
