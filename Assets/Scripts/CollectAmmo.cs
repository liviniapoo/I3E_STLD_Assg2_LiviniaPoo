/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * Destroys ammo asset upon collection
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAmmo : MonoBehaviour
{
    /// <summary>
    /// Function destroys ammo on collection
    /// </summary>
    public void AmmoCollect()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().AmmoUpdate(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().AmmoUpdate(null);
        }
    }
}
