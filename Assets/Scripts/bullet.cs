using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Set velocity to direction shot in times speed
        rb.velocity = new Vector3(transform.localScale.x * speed, 0f, 0f);
    }

    void onHit(Collider2D HIT)
    {
        Debug.Log(HIT.name);
        Destroy(gameObject);
    }
}
