/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * Opening Ship Doors using Time and Lerp
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoor : MonoBehaviour
{
    public float openDuration;
    float currentDuration;
    bool opening = false;
    bool opened = false;

    Vector3 startPosition;
    Vector3 targetPosition;

    public void OpenShipDoor()
    {
        if (!opening && !opened)
        {
            startPosition = transform.position;
            targetPosition = startPosition;
            targetPosition.x += 90f;

            opening = true;
        }
    }

    private void Update()
    {
        if (opening)
        {
            currentDuration += Time.deltaTime;
            float t = currentDuration / openDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            if (currentDuration >= openDuration)
            {
                opening = false;
                transform.position = targetPosition;
                opened = true;
                Debug.Log("Door opened");
            }
        }
    }

}
