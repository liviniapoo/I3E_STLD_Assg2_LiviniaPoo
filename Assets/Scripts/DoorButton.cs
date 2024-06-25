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
            door.GetComponent<doorController>().openDoor();
            opened = true;

        }else if (opened)
        {
            door.GetComponent<doorController>().closeDoor();
            opened = false;

        }

    }
}
