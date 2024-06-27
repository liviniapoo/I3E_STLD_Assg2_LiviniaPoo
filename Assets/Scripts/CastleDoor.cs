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
    public float moveDuration;
    float currentDuration;
    bool opening = false;
    public bool opened = false;

    [SerializeField]
    private Vector3 moveVector;
    private Vector3 targetPosition;
    private Vector3 startPosition;

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
                    Debug.Log("Door opened");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*Debug.Log("triggered");*/
        if (other.tag == "Player")
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        OpenCastleGate();

    }
}
