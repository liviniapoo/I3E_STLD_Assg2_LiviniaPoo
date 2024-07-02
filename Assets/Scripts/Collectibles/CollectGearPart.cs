/*
 * Author: Livinia Poo
 * Date: 27/06/2024
 * Description: 
 * Destroys gear asset upon collection using parent class, increases gear count
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGearPart : Collectible
{
    /// <summary>
    /// Uses collect function from parent, adds player's gear part count
    /// </summary>
    public override void Collect()
    {
        base.Collect();
        Player.gearCount++;
    }
}
