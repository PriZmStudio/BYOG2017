using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {
    
    GameObject eye_left, eye_right;

    enum Direction
    {
        LEFT = 1, RIGHT = 2
    }

    float eye_on_time = 1.0f, eye_off_time = 0.5f;

    int currentLookAtDirection;

	// Use this for initialization
	void Start () {
        eye_left = gameObject.transform.GetChild(0).gameObject;
        eye_right = gameObject.transform.GetChild(1).gameObject;
        StartCoroutine(Blink());
        currentLookAtDirection = (int)Direction.RIGHT;
        look_right();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLookAtDirection == (int)Direction.LEFT) {
            currentLookAtDirection = (int)Direction.RIGHT;
            look_right();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLookAtDirection == (int)Direction.RIGHT)
        {
            currentLookAtDirection = (int)Direction.LEFT;
            look_left();
        }
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(eye_on_time);
        eye_left.SetActive(false);
        eye_right.SetActive(false);
        yield return new WaitForSeconds(eye_off_time);
        eye_left.SetActive(true);
        eye_right.SetActive(true);
        StartCoroutine(Blink());
    }

    void look_right()
    {
        eye_left.transform.localPosition = new Vector3(-0.023f, eye_left.transform.localPosition.y, eye_left.transform.localPosition.z);
        eye_right.transform.localPosition = new Vector3(0.073f, eye_right.transform.localPosition.y, eye_right.transform.localPosition.z);
    }

    void look_left()
    {
        eye_left.transform.localPosition = new Vector3(-0.079f, eye_left.transform.localPosition.y, eye_left.transform.localPosition.z);
        eye_right.transform.localPosition = new Vector3(0.021f, eye_right.transform.localPosition.y, eye_right.transform.localPosition.z);
    }
}
