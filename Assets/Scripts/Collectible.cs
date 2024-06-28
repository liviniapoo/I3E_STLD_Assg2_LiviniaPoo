/*
 * Author: Livinia Poo
 * Date: 28/06/2024
 * Description: 
 * Destroys all child-collectible class gameobjects upon collection
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public virtual void Collect()
    {
        Destroy(gameObject);
    }
}
