using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour {

    public static List<Memory> collectedMemories = new List<Memory>();
    int totalMemories;

    public static int mems;

    GameObject camera;

    [SerializeField]
    Sprite doorClosed, doorOpen;

    [SerializeField]
    AnimateDiaryImage diaryImage;

    [SerializeField]
    Thunder thunder;

    int doOnce;

    public bool won;

	// Use this for initialization
	void Start () {
        won = false;
        collectedMemories.Clear();
        totalMemories = GameObject.Find("Memories").transform.childCount;
        mems = totalMemories;

        camera = GameObject.Find("Camera");
        GetComponent<SpriteRenderer>().sprite = doorClosed;
        doOnce = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (allMemoriesCollected() && doOnce == 0) {
            doOnce++;
            GetComponent<SpriteRenderer>().sprite = doorOpen;
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player") {
            if (allMemoriesCollected())
            {
                thunder.startThunder();
                won = true;
                camera.GetComponent<Fading>().BeginFade(1);
                //diaryImage.ShowImage();
                StartCoroutine(nextLevel());
            }
        }
    }

    public int memoriesCollected()
    {
        return collectedMemories.Count;
    }

    public int getTotalMemories()
    {
        return totalMemories;
    }

    public bool allMemoriesCollected()
    {
        return collectedMemories.Count == totalMemories;
    }

    public void collectMemories(Memory memory)
    {
        collectedMemories.Add(memory);
    }

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(0.5f);
        diaryImage.ShowImage();
        yield return new WaitForSeconds(1.5f);
        camera.GetComponent<Fading>().BeginFade(-1);
        //diaryImage.ShowImage();
        yield return new WaitForSeconds(6.0f);
        camera.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
