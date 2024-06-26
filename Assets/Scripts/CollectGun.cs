/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * Destroys gun asset upon collection
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGun : Interactable
{
    /*private bool gunInv;*/

    /// <summary>
    /// Function destroys gun on collection
    /// </summary>
    public void GunCollect()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().GunUpdate(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().GunUpdate(null);
        }
    }

    /*public override void Interact()
    {
        if (gunInv.GetComponent<Player>().hasGun == false)
        {
            Destroy(gameObject);
            gunInv = true;
            gunInv.GetComponent<Player>().hasGun == true;
        }
        else
        {
            Debug.Log("alr have");
        }
    }*/
}
