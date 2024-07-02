/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * Destroys ammo asset upon collection using parent class, increases ammo count
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAmmo : Collectible
{
    /// <summary>
    /// Uses collect function from parent, adds player's ammobox and ammo count
    /// </summary>
    public override void Collect()
    {
        base.Collect();
        Player.ammoBoxCount++;
        Player.ammoCount += 15;
    }
}
