using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTrail : MonoBehaviour
{
    public float spawnTime;
    public float fadeSpeed;
    public int firstSpriteOrder;
    public GameObject trailSprite;
    public Color trailColor;

    int curSpriteOrder;

    public void startTrail()
    {
        // First trail sprite has sorting order of firstSpriteOrder
        curSpriteOrder = firstSpriteOrder;

        // Restart calling spawnTrailSprite every spawnTime seconds
        CancelInvoke("spawnTrailSprite");
        InvokeRepeating("spawnTrailSprite", 0.0f, spawnTime);
    }

    public void stopTrail()
    {
        // Stop calling spawnTrailSprite
        CancelInvoke("spawnTrailSprite");
    }

    void spawnTrailSprite()
    {
        // Create new trail sprite GameObject
        GameObject newTrailSprite = Instantiate(trailSprite);
        newTrailSprite.transform.position = transform.position;
        newTrailSprite.transform.localScale = transform.localScale;

        // Set sprite renderer values for trail sprite
        SpriteRenderer sr = newTrailSprite.GetComponent<SpriteRenderer>();
        sr.sprite = GetComponent<SpriteRenderer>().sprite;
        sr.color = trailColor;
        sr.sortingOrder = curSpriteOrder;

        // Next trail sprite has sorting order one higher
        ++curSpriteOrder;

        // Set fade speed in trail sprite
        newTrailSprite.GetComponent<FadeOut>().fadeSpeed = fadeSpeed;
    }
}
