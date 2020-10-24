using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShot : MonoBehaviour
{

    public int health = 3;
    void Update() {
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log("Trigger collision detected. Collision name = " + coll.gameObject.name);
        Destroy(coll.gameObject);
        health -= 1;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
