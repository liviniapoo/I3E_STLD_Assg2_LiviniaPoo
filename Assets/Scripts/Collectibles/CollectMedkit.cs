/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * Destroys medkit asset upon collection using parent class, increases medkit count
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMedkit : Collectible
{
    /// <summary>
    /// Uses collect function from parent, adds player's medkit count
    /// </summary>
    public override void Collect()
    {
        base.Collect();
        Player.medkitCount++;
    }
}
