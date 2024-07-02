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
    /// <summary>
    /// Setting up variables to run the Lerp smoothly
    /// </summary>
    public float moveDuration;
    float currentDuration;
    bool fallen = false;
    bool falling = false;

    /// <summary>
    /// Determining where the door should move to
    /// </summary>
    [SerializeField]
    private float moveVector;
    private Vector3 targetRotation;
    private Vector3 startRotation;

    ///<summary>
    /// Referencing Audio Clips for Effects
    /// </summary>
    public AudioSource sfxAudio;

    /// <summary>
    /// Calls the tree fall function upon player entering trigger
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            TreeFallEvent();
            sfxAudio.Play();
        }
    }

    /// <summary>
    /// Performs the lerp of moving the tree to be an obstacle, resets duration timer
    /// </summary>
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

    /// <summary>
    /// Uses time functions to properly execute lerp
    /// </summary>
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
            }
        }
    }
}
