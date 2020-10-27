using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Set in the Unity Editor
    public float maxSpeed;
    public float jumpVelocity;
    public float dashMultiplier;
    public float dashTime;

    // Defined by the script
    Rigidbody2D rb2d;
    Vector2 colliderLowerLeft;
    Vector2 colliderLowerRight;
    LayerMask groundMask;
    GameObject respawnPoint;
    bool dashing;
    float dashDir;

    // Start is called before the first frame update
    void Start()
    {
        // Get player Rigidbody2D
        rb2d = GetComponent<Rigidbody2D>();

        // Get bottom corners of the player's collider
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        colliderLowerLeft = new Vector2(collider.offset.x - collider.size.x / 2.0f,
                                        collider.offset.y - collider.size.y / 2.0f);
        colliderLowerRight = new Vector2(collider.offset.x + collider.size.x / 2.0f,
                                         collider.offset.y - collider.size.y / 2.0f);

        // Get a ground layer mask for raycasts that can only hit ground
        groundMask = LayerMask.GetMask("Ground");

        // Get respawn point
        respawnPoint = GameObject.FindWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        // Get left and right input (-1.0f to 1.0f)
        float horizontal = Input.GetAxis("Horizontal");

        // Flip player if they are moving in the opposite direction
        if (horizontal != 0.0f && Mathf.Sign(horizontal) == -transform.localScale.x)
        {
            flipPlayer();
        }

        // Velocities to be applied to the player
        float horizVel = horizontal * maxSpeed;
        float vertVel = rb2d.velocity.y;

        // Check if the jump button has been pressed and the player is grounded
        if (Input.GetButton("Jump") && isGrounded())
        {
            // Set new vertical velocity to jump velocity
            vertVel = jumpVelocity;

            // Reset gravity (for jumping while dashing)
            rb2d.gravityScale = 3.0f;
        }

        // Run once when the dash is started
        if (Input.GetButtonDown("Dash") && horizontal != 0.0f && !dashing)
        {
            vertVel = 0.0f;
            StartCoroutine("Dash");
        }

        // Run for multiple frames while dashing
        if (dashing)
        {
            horizVel *= dashMultiplier;
            
            // Stop dash when the player turns around or stops moving
            if (transform.localScale.x != dashDir || rb2d.velocity.x == 0.0f)
            {
                StopCoroutine("Dash");
                stopDash();
            }
        }
        
        // Apply velocities to the player
        rb2d.velocity = new Vector2(horizVel, vertVel);
    }

    IEnumerator Dash()
    {
        dashing = true;
        dashDir = transform.localScale.x;
        rb2d.gravityScale = 0.0f;

        // Pause for set time and then stop dash
        yield return new WaitForSecondsRealtime(dashTime);
        stopDash();
    }

    void stopDash()
    {
        dashing = false;
        rb2d.gravityScale = 3.0f;
    }

    bool isGrounded()
    {
        // Get current player lower corner positions
        Vector2 lowerLeftPos = (Vector2)transform.position + colliderLowerLeft;
        Vector2 lowerRightPos = (Vector2)transform.position + colliderLowerRight;

        // Cast rays down from the lower corners of the player collider
        RaycastHit2D leftHit = Physics2D.Raycast(lowerLeftPos, Vector2.down, 0.02f, groundMask);
        RaycastHit2D rightHit = Physics2D.Raycast(lowerRightPos, Vector2.down, 0.02f, groundMask);

        // Draw rays for debugging
        // drawGroundCheckRays(lowerLeftPos, lowerRightPos, leftHit, rightHit);

        // The player is grounded if the left or right ray hit ground
        return leftHit || rightHit;
    }

    // Debug function for drawing ground check rays
    void drawGroundCheckRays(Vector2 lowerLeftPos, Vector2 lowerRightPos, bool leftHit, bool rightHit)
    {
        // The lines are green for hits and red for misses
        Color leftDebugColor = Color.green;
        Color rightDebugColor = Color.green;
        if (!leftHit)
            leftDebugColor = Color.red;
        if (!rightHit)
            rightDebugColor = Color.red;

        Debug.DrawRay(lowerLeftPos, 0.02f * Vector2.down, leftDebugColor);
        Debug.DrawRay(lowerRightPos, 0.02f * Vector2.down, rightDebugColor);
    }

    void flipPlayer()
    {
        Vector3 flippedScale = transform.localScale;
        flippedScale.x *= -1;
        transform.localScale = flippedScale;
    }

    public void respawn()
    {
        transform.position = respawnPoint.transform.position;
        rb2d.velocity = Vector3.zero;
    }
}
