using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float fadeSpeed;
    public bool destroy;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Fade out sprite while visible and script is enabled
        if (sr.color.a > 0)
        {
            // Reduce sprite alpha
            Color newColor = sr.color;
            newColor.a -= fadeSpeed * Time.deltaTime;
            sr.color = newColor;

            // Destroy GameObject if needed
            if (sr.color.a <= 0 && destroy)
            {
                Destroy(gameObject);
            }
        }
    }
}
