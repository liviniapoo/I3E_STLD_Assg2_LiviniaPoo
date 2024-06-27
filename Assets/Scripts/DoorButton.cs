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
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject doorPanel;
    private bool opened = false;
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
