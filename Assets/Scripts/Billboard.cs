/*
 * Author: Livinia Poo
 * Date: 1/07/2024
 * Description: 
 * Allowing enemy healthbar to rotate and face player camera
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    /// <summary>
    /// Attach gameobject camera for UI to track
    /// </summary>
    public Transform cam;

    /// <summary>
    /// Called after each update, points UI to face the Player's camera
    /// </summary>
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
