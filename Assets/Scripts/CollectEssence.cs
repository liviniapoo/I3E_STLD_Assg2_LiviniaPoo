/*
 * Author: Livinia Poo
 * Date: 28/06/2024
 * Description: 
 * Destroys essence asset upon collection using parent class, declares player has crystal essence
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEssence : Collectible
{
    /// <summary>
    /// Uses collect function from parent, declares that player has collected the crystal essence
    /// </summary>
    public override void Collect()
    {
        base.Collect();
        Player.essenceCollected = true;
    }
}
