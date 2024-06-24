/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private NormalDoor normalDoor;

    void OnInteract()
    {
        if (normalDoor != null)
        {
            normalDoor.OpenShipDoor();
        }
    }
}
