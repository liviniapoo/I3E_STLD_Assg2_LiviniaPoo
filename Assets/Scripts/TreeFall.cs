/*
 * Author: Livinia Poo
 * Date: 27/06/2024
 * Description: 
 * Triggering the Tree-Fall Obstacle with Lerp
 */


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
    public float moveDuration;
    float currentDuration;
    bool fallen = false;
    bool falling = false;

    [SerializeField]
    private float moveVector;
    private Vector3 targetRotation;
    private Vector3 startRotation;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TreeFallEvent();
        }
    }

    public void TreeFallEvent()
    {
        if (!fallen)
        {
            startRotation = transform.eulerAngles;
            targetRotation = startRotation;
            targetRotation.z += moveVector;

            falling = true;

            currentDuration = 0;
        }
    }

    private void Update()
    {
        if (falling)
        {
            currentDuration += Time.deltaTime;
            float t = currentDuration / moveDuration;
            transform.eulerAngles = Vector3.Lerp(startRotation, targetRotation, t);

            if (currentDuration >= moveDuration)
            {
                transform.eulerAngles = targetRotation;
                falling = false;
                fallen = true;
                Debug.Log("Oh No! A tree is blocking!");
            }
        }
    }
}
