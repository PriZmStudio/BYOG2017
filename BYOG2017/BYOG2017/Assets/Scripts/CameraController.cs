using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject target;
    
    Camera camera;

    Vector3 screenPos;
    Rigidbody2D rb, playerRb;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();

        if (target != null) {
            playerRb = target.GetComponent<Rigidbody2D>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        //screenPos = camera.WorldToScreenPoint(target.position);
        screenPos = camera.WorldToViewportPoint(target.transform.position);
        
        float horizontalSpeed = (screenPos.x <= 0.2 || screenPos.x >= 0.8) ? playerRb.velocity.x : 0.0f;
        rb.velocity = new Vector2(horizontalSpeed, 0.0f);
	}
}
