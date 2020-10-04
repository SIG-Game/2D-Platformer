using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Set in the Unity Editor
    public float maxSpeed;
    public float jumpVelocity;

    // Defined by the script
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        // Get player Rigidbody2D
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get left and right input (-1.0f to 1.0f)
        float horizontal = Input.GetAxis("Horizontal");

        // Velocities to be applied to the player
        float horizVel = horizontal * maxSpeed;
        float vertVel = rb2d.velocity.y;

        // Check if the jump button has just been pressed
        if (Input.GetButtonDown("Jump"))
        {
            // Set new vertical velocity to jump velocity
            vertVel = jumpVelocity;
        }

        // Apply velocities to the player
        rb2d.velocity = new Vector2(horizVel, vertVel);
    }
}
