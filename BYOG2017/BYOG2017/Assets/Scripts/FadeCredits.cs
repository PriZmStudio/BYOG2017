using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FadeCredits : MonoBehaviour {

    int doOnce = 0;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && doOnce == 0)
        {
            doOnce++;
            Fade();
        }
    }

    void Fade()
    {
        GetComponent<TextMeshProUGUI>().DOFade(0.0f, 2.0f);
    }
}
