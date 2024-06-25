/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * Opening Individual Ship Doors using Time and Lerp
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoor : MonoBehaviour
{
    public float moveDuration;
    float currentDuration;
    bool opening = false;
    public bool opened = false;
    bool closing = false;

    [SerializeField]
    private Vector3 moveVector;
    private Vector3 targetPosition;
    private Vector3 startPosition;

    public void OpenShipDoor()
    {
        if (!opening && !opened)
        {
            startPosition = transform.position;
            targetPosition = transform.position + moveVector;

            opening = true;
            closing = false;

            currentDuration = 0;
        }
    }

    public void CloseShipDoor()
    {
        if (opened && !closing)
        {
            startPosition = transform.position;
            targetPosition = transform.position - moveVector;

            closing = true;
            opening = false; 

            currentDuration = 0;
        }
    }


    private void Update()
    {
        if (opening || closing)
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
                else if (closing)
                {
                    closing = false;
                    opened = false;
                    Debug.Log("Door closed");
                }
            }
        }
    }
}
