/*
 * Author: Livinia Poo
 * Date: 25/06/2024
 * Description: 
 * Interacting with the door buttons to open
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : Interactable
{
    /// <summary>
    /// Attaching the necessary door components to the button so the script knows which doors to move
    /// </summary>
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject doorPanel;

    /// <summary>
    /// Sets the door to closed state
    /// </summary>
    private bool opened = false;

    /// <summary>
    /// Using Interactable parent class, opens and closes door when button is interacted with depending on current state
    /// </summary>
    public override void Interact()
    {
        Debug.Log("called");
        if (!opened)
        {
            door.GetComponent<doorController>().OpenDoor();
            opened = true;

        }else if (opened)
        {
            door.GetComponent<doorController>().CloseDoor();
            opened = false;

        }

    }
}
