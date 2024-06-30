/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * Raycast Management for Player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    ///<summary>
    ///Setting up Raycasting of Player
    ///</summary>
    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    float interactionDistance;

    /// <summary>
    /// Referencing scripts that utilise raycast
    /// </summary>
    Interactable currentInteractable;
    Collectible currentCollectible;
    GemstoneLock gemstoneLockLook;
    RepairShip serverRepair;

    /// <summary>
    /// Checks what item is hit by raycast every update
    /// </summary>
    private void Update()
    {
        Debug.DrawRay(playerCamera.position, playerCamera.TransformDirection(Vector3.forward) * interactionDistance, Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            
            if (hitInfo.transform.TryGetComponent<Interactable>(out currentInteractable))
            {
                Debug.Log(hitInfo.transform.name);
            }
            else
            {
                currentInteractable = null;
            }

            if (hitInfo.transform.TryGetComponent<Collectible>(out currentCollectible))
            {
            }
            else
            {
                currentCollectible = null;
            }
            if (hitInfo.transform.TryGetComponent<GemstoneLock>(out gemstoneLockLook))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);
            }
            else
            {
                gemstoneLockLook = null;
            }

            if (hitInfo.transform.TryGetComponent<RepairShip>(out serverRepair))
            {
            }
            else
            {
                serverRepair = null;
            }
        }
    }

    /// <summary>
    /// If appropriate mesh is detected and interacted, their respective functions are called
    /// </summary>
    public void OnInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }

        if (currentCollectible != null)
        {
            currentCollectible.Collect();
        }

        if (gemstoneLockLook != null)
        {
            if (Player.gemstoneCollected == true)
            {
                gemstoneLockLook.PlaceGem();
            }
            else
            {
                print("Find the gem.");
            }
        }

        if (serverRepair != null)
        {
            if (RepairShip.materialsCheck)
            {
                Debug.Log("Ship fixed");
                serverRepair.FixShip();
                RepairShip.shipFixed = true;
            }
            else
            {
                Debug.Log("Missing materials");
            }
        }
    }
}
