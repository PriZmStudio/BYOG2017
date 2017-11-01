using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {
    CameraShake cameraShake;
    GameObject camera;

    Door door;

    [SerializeField]
    GameObject deathParticle, playerGFX, eyes;

    bool isDead;

	// Use this for initialization
	void Start () {
        door = GameObject.Find("door").GetComponent<Door>();
        isDead = false;

        camera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraShake = camera.GetComponent<CameraShake>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -10.0f && !door.won) {
            KillPlayer();
        }
	}

    public void KillPlayer()
    {
        if (!isDead)
        {
            StartCoroutine(Kill());
            isDead = true;
            eyes.SetActive(false);
            //camera.GetComponent<CameraController>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            GetComponent<PlayerController>().enabled = false;
            GetComponent<PlayerMotor>().enabled = false;
            playerGFX.GetComponent<SpriteRenderer>().enabled = false;
            playerGFX.GetComponent<GhostSprites>().enabled = false;
            //cameraShake.Shake(0.05f, 0.1f);
        }
    }

    IEnumerator Kill()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
