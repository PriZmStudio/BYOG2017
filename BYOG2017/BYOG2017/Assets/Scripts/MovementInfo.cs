using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();

#if UNITY_STANDALONE || UNITY_WEBPLAYER
        text.text = "Move with left/right arrow";
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        text.text = "Touch left/right side to move";
#endif
    }

    // Update is called once per frame
    void Update () {
		
	}
}
