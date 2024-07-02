/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * Destroys gun asset upon collection using parent class, declares player has a gun
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGun : Collectible
{
    /// <summary>
    /// Uses collect function from parent, declares player has a gun
    /// </summary>
    public override void Collect()
    {
        if (Player.hasGun == true)
        {
            Debug.Log("already hv");
        }
        else
        {
            base.Collect();
            Player.hasGun = true;
        }
    }
}
