using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour {

    public static List<Memory> collectedMemories = new List<Memory>();
    int totalMemories;

    GameObject camera;

	// Use this for initialization
	void Start () {
        collectedMemories.Clear();
        totalMemories = GameObject.Find("Memories").transform.childCount;
        print(totalMemories);

        camera = GameObject.Find("Camera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player") {
            if (allMemoriesCollected())
            {
                print("NEXT LEVEL");
                camera.GetComponent<Fading>().BeginFade(1);
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
}
