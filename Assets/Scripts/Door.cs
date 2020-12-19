using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interaction
{
    public GameObject player;
    public Door destinationDoor;

    public override void Interact()
    {
        // Get destination position for player
        Vector3 destPosition = destinationDoor.transform.position;

        // Calculate destination position based on size of door and player colliders
        destPosition.y -= GetComponent<BoxCollider2D>().size.y / 2.0f;
        destPosition.y += player.GetComponent<BoxCollider2D>().size.y / 2.0f;

        player.transform.position = destPosition;

        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
