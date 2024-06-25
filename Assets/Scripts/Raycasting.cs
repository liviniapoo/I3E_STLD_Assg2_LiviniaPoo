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
    ///
    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    float interactionDistance;

    Interactable currentInteractable;
    private void Update()
    {
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            /*Debug.Log(hitInfo.transform.name);*/
            if (hitInfo.transform.TryGetComponent<Interactable>(out currentInteractable))
            {
            }
            else
            {
                currentInteractable = null;
            }
        }
        else
        {
            currentInteractable = null;
        }


    }
    void OnInteract()
    {
        if(currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
}
