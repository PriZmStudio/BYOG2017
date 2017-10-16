using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BreakPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            StartCoroutine(breakPlatform());
        }
    }

    IEnumerator breakPlatform()
    {
        yield return new WaitForSeconds(3.0f);
        rb.constraints = 0;
        rb.gravityScale = 1.0f;
        rb.AddForce(new Vector2(0.0f, -10.0f));
    }
}
