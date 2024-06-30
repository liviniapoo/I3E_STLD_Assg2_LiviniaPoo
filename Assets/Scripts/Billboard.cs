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
    public Transform cam;

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
