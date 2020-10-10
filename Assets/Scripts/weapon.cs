using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletpre;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot ()
    {
        GameObject bullet = Instantiate(bulletpre, firePoint.position, firePoint.rotation);

        // Set bullet x scale to player x scale (flips bullet if needed)
        Vector3 newScale = new Vector3(transform.parent.localScale.x, 1f, 1f);
        bullet.transform.localScale = newScale;
    }
}
