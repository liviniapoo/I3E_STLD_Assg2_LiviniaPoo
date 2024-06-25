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
    /*Door Handling*/
    private NormalDoor normalDoor;

    public void DoorUpdate(NormalDoor doorPos)
    {
        normalDoor = doorPos;
    }


    /*Gun Handling*/
    /// <summary>
    /// Variables to check whether player has a gun
    /// </summary>
    public bool hasGun = false;

    private CollectGun gunFront;

    ///<summary>
    /// Checking Gun in front
    /// </summary>
    public void GunUpdate(CollectGun gunPos)
    {
        gunFront = gunPos;
    }

    /*Ammo Handling*/
    /// <summary>
    /// Variables to check how much ammo player has
    /// </summary>
    public int ammoBoxCount = 0;
    public int ammoCount = 0;

    private CollectAmmo ammoFront;

    /// <summary>
    /// Checking ammo in front
    /// </summary>
    /// <param name="ammoPos"></param>
    public void AmmoUpdate(CollectAmmo ammoPos)
    {
        ammoFront = ammoPos;
    }

    /*Medkit Handling*/
    /// <summary>
    /// Variable to check how many medkits player has
    /// </summary>
    public int medkitCount = 0;

    private CollectMedkit medkitFront;

    /// <summary>
    /// Checking Medkit front
    /// </summary>
    public void MedkitUpdate(CollectMedkit medkitPos)
    {
        medkitFront = medkitPos;
    }

    void OnInteract()
    {
        if (gunFront != null)
        {
            if (hasGun)
            {
                Debug.Log("Already have");
            }
            else
            {
                gunFront.GunCollect();
                hasGun = true;

                Debug.Log("gun col");
            }
        }

        if (ammoFront != null)
        {
            ammoFront.AmmoCollect();
            ammoCount += 25;
            ammoBoxCount += 1;

            Debug.Log(ammoCount);
            Debug.Log(ammoBoxCount);
        }

        if (medkitFront != null)
        {
            medkitFront.MedkitCollect();
            medkitCount += 1;

            Debug.Log(medkitCount);
        }

        if (normalDoor != null)
        {
            normalDoor.OpenShipDoor();
        }
    }

}
