using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MemoryStatusIndicator : MonoBehaviour {
    
    [SerializeField]
    GameObject status;

    Door door;
	// Use this for initialization
	void Start () {
        status.GetComponent<TextMeshProUGUI>().alpha = 0.0f;
        status.GetComponent<TextMeshProUGUI>().text = "test";
        door = GameObject.FindGameObjectWithTag("door").GetComponent<Door>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.T))
            showStatus(0, 1);
            
	}

    public void showStatus(int memoriesCollected, int total)
    {
        status.GetComponent<TextMeshProUGUI>().text = memoriesCollected + " / " + total;
        status.GetComponent<TextMeshProUGUI>().alpha = 1.0f;
        status.GetComponent<Animation>().Play();
        Fade();
    }

    void Fade()
    {
        status.GetComponent<TextMeshProUGUI>().DOFade(0.0f, 1.0f);
    }
}
