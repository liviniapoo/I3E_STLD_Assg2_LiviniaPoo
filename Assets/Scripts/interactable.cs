/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * Parents all interactable objects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    /// <summary>
    /// All child classes will allow gameobject to be interacted with
    /// </summary>
    public virtual void Interact()
    {
        Debug.Log("interact");
    }
}
