using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Image))]
public class Thunder : MonoBehaviour {

    Image thunder;
	// Use this for initialization
	void Start () {
        thunder = GetComponent<Image>();
	}

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.T))
            startThunder();
            */
    }

    public void startThunder()
    {
        thunder.DOFade(1.0f, 0.1f);
        StartCoroutine(turnOffThunder());
    }

    IEnumerator turnOffThunder()
    {
        yield return new WaitForSeconds(0.1f);
        thunder.DOFade(0.0f, 0.5f);
    }
}
