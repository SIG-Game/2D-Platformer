using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        // Call respawn function when colliding with player
        if (coll.gameObject.tag == "Player")
            coll.gameObject.GetComponent<PlayerController>().respawn();
    }
}
