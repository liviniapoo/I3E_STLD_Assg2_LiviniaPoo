/*
 * Author: Livinia Poo
 * Date: 27/06/2024
 * Description: 
 * Opening the Castle Door after event
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CastleDoor : MonoBehaviour
{
    /// <summary>
    /// Setting up variables to run the Lerp smoothly
    /// </summary>
    public float moveDuration;
    float currentDuration;
    bool opening = false;
    public bool opened = false;

    /// <summary>
    /// Determining where the door should move to
    /// </summary>
    [SerializeField]
    private Vector3 moveVector;
    private Vector3 targetPosition;
    private Vector3 startPosition;

    /// <summary>
    /// Moves the door to the target open position based on given information, resets Duration timer
    /// </summary>
    public void OpenCastleGate()
    {
        if (!opening && !opened)
        {
            startPosition = transform.position;
            targetPosition = transform.position + moveVector;

            opening = true;

            currentDuration = 0;
        }
    }

    /// <summary>
    /// Performs the Lerp using Time functions
    /// </summary>
    private void Update()
    {
        if (opening)
        {
            currentDuration += Time.deltaTime;
            float t = currentDuration / moveDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            if (currentDuration >= moveDuration)
            {
                transform.position = targetPosition;
                if (opening)
                {
                    opening = false;
                    opened = true;
                }
            }
        }
    }

    /// <summary>
    /// Checks whether the door is unlocked by the gem and opens on trigger
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(GemstoneLock.gemPlaced == true)
            {
                OpenCastleGate();
            }
        }
    }

    /*public void OpenDoor()
    {
        OpenCastleGate();

    }*/
}
