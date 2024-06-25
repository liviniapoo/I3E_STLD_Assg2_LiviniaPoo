/*
 * Author: Livinia Poo
 * Date: 25/06/2024
 * Description: 
 * Using Triggers to close and open doors
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    [SerializeField]
    private GameObject rightDoor;
    
    public GameObject leftDoor;

    private void OnTriggerEnter(Collider other)
    {
        /*Debug.Log("triggered");*/
        if(other.tag=="Player")
        {
            openDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            closeDoor();
        }
    }
    public void openDoor()
    {
        /*Debug.Log("dhjkfbasdjikbf");*/
        rightDoor.GetComponent<NormalDoor>().OpenShipDoor();
        leftDoor.GetComponent<NormalDoor>().OpenShipDoor();

    }
    public void closeDoor()
    {

        rightDoor.GetComponent<NormalDoor>().CloseShipDoor();
        leftDoor.GetComponent<NormalDoor>().CloseShipDoor();
    }
}