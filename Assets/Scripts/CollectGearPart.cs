/*
 * Author: Livinia Poo
 * Date: 27/06/2024
 * Description: 
 * Destroys gear asset upon collection
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGearPart : MonoBehaviour
{
    public void GearCollect()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().GearUpdate(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().GearUpdate(null);
        }
    }
}
