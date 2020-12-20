using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* NOTE: This script is not currently being used.
 * Its functionality is replicated through Cinemachine.
 * This file is kept in case reversion is needed.
 */

public class CameraFollow : MonoBehaviour
{
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.z = -10;
        transform.position = targetPosition;
    }
}
