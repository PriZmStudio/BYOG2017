using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour {

    public static List<Memory> collectedMemories = new List<Memory>();
    int totalMemories;

    GameObject camera;

    [SerializeField]
    Sprite doorClosed, doorOpen;

    int doOnce;

	// Use this for initialization
	void Start () {
        collectedMemories.Clear();
        totalMemories = GameObject.Find("Memories").transform.childCount;
        print(totalMemories);

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
                print("NEXT LEVEL");
                camera.GetComponent<Fading>().BeginFade(1);
                StartCoroutine(nextLevel());
            }
        }
    }

    bool allMemoriesCollected()
    {
        return collectedMemories.Count == totalMemories;
    }

    public void collectMemories(Memory memory)
    {
        collectedMemories.Add(memory);
    }

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
