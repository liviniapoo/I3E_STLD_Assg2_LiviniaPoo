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
    /// <summary>
    /// Attaching the two doors to the same gameobject
    /// </summary>
    [SerializeField]
    private GameObject rightDoor;
    public GameObject leftDoor;

    ///<summary>
    /// Referencing Audio Clips for Effects
    /// </summary>
    public AudioSource sfxOpeningAudio;
    public AudioSource sfxClosingAudio;

    /// <summary>
    /// Opens the door upon player entering trigger area
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        /*Debug.Log("triggered");*/
        if(other.tag=="Player")
        {
            OpenDoor();
        }
    }

    /// <summary>
    /// Closes the door upon player leaving trigger area
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CloseDoor();
        }
    }

    /// <summary>
    /// Opens each side of the door in the same function
    /// </summary>
    public void OpenDoor()
    {
        rightDoor.GetComponent<NormalDoor>().OpenShipDoor();
        leftDoor.GetComponent<NormalDoor>().OpenShipDoor();
        sfxOpeningAudio.Play();
    }
    /// <summary>
    /// Closes each side of the door in the same function
    /// </summary>
    public void CloseDoor()
    {
        rightDoor.GetComponent<NormalDoor>().CloseShipDoor();
        leftDoor.GetComponent<NormalDoor>().CloseShipDoor();
        sfxClosingAudio.Play();
    }
}
